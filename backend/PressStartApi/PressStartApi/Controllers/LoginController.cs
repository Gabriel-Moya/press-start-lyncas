using Microsoft.AspNetCore.Mvc;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Interfaces;

namespace PressStartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> Login(LoginDTO loginDTO)
        {
            UserResponseDTO user = await _loginService.Login(loginDTO);
            return user;
        }
    }
}
