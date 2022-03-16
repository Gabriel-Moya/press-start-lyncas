using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PressStartApi.DTO;
using PressStartApi.Models;
using PressStartApi.Validations;
using System.Linq;
using System.Text.RegularExpressions;

namespace PressStartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsersController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.User.Include(x => x.Authentication).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = _context.Set<User>().Include(x => x.Authentication).SingleOrDefault(x => x.Id == id);
            if (user == null)
                return BadRequest("Usuário não encontrado.");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<InsertUserDTO>>> AddUser(InsertUserDTO user)
        {
            ValidatorUser validator = new ValidatorUser();
            ValidationResult results = validator.Validate(user);

            if(!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            string phoneReplaced = Regex.Replace(user.Phone, @"\D", "");
            user.Phone = phoneReplaced;

            User _user = _mapper.Map<InsertUserDTO, User>(user);

            _user.Authentication.UserId = _user.Id;
            _user.Authentication.Password = user.Password;
            _user.Authentication.IsActive = user.IsActive;

            _context.User.Add(_user);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<InsertUserDTO>>> UpdateUser(int id, InsertUserDTO request)
        {
            ValidatorUser validator = new ValidatorUser();
            ValidationResult results = validator.Validate(request);

            var dbUser = await _context.User.Include(x => x.Authentication).SingleOrDefaultAsync(x => x.Id == id);

            _mapper.Map(request, dbUser);

            if (dbUser == null)
                return BadRequest("Usuário não encontrado.");

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            dbUser.Authentication.Password = request.Password;
            dbUser.Authentication.IsActive = request.IsActive;

            _context.Update(dbUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var dbUser = await _context.User.FindAsync(id);
            if (dbUser == null)
                return BadRequest("Usuário não encontrado.");

            _context.User.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.User.ToListAsync());
        }
    }
}
