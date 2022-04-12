using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LoginController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Login(LoginDTO loginDTO)
        {
            try
            {
                User user = await _context.Set<User>()
                                    .Include(x => x.Authentication)
                                    .FirstAsync(x => x.Email == loginDTO.Email &&
                                    x.Authentication.Password == loginDTO.Password);

                return Ok(_mapper.Map<UserResponseDTO>(user));
            }
            catch
            {
                return Unauthorized(new
                {
                    message = "Usuário não autorizado"
                });
            }
        }
    }
}
