using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PressStartApi.DTO;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Models;
using PressStartApi.Validations;
using PressStartApi.Validators;
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
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> Get()
        {
            List<User> users = await _context.User.Include(x => x.Authentication).AsNoTracking().ToListAsync();

            List<UserResponseDTO> usersResponse = _mapper.Map<List<UserResponseDTO>>(users);

            return usersResponse;
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
        public async Task<ActionResult<List<UserResponseDTO>>> AddUser(InsertUserDTO user)
        {
            ValidatorUser validator = new ValidatorUser();
            ValidationResult results = validator.Validate(user);

            if(!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            string phoneReplaced = Regex.Replace(user.Phone, @"\D", "");
            user.Phone = phoneReplaced;

            try
            {
                User _user = _mapper.Map<User>(user);

                _context.Add(_user);

                await _context.SaveChangesAsync();
                return Ok(_mapper.Map<UserResponseDTO>(_user));
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel criar o usuario." });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UpdateUserDTO>>> UpdateUser(int id, UpdateUserDTO request)
        {
            ValidatorPostUser validator = new ValidatorPostUser();
            ValidationResult results = validator.Validate(request);

            var dbUser = await _context.User.Include(x => x.Authentication).SingleOrDefaultAsync(x => x.Id == id);

            if (dbUser == null)
                return BadRequest("Usuário não encontrado.");

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            string phoneReplaced = Regex.Replace(request.Phone, @"\D", "");
            request.Phone = phoneReplaced;

            _mapper.Map(request, dbUser);

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
