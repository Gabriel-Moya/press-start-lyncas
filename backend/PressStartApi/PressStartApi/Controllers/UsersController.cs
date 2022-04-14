using ApiLyncas.Authorization;
using Microsoft.AspNetCore.Mvc;
using PressStartApi.DTO.Response;
using PressStartApi.Interfaces;
using PressStartApi.Models;

namespace PressStartApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> Get()
        {
            return Ok(await _userService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDTO>> AddUser(DTO.Request.SendUserDTO user)
        {
            return Ok(await _userService.AddUser(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<DTO.Request.SendUserDTO>>> UpdateUser(int id, DTO.Request.SendUserDTO request)
        {
            return Ok(await _userService.UpdateUser(id, request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return Ok(new {message = "Usuário deletado"});
        }
    }
}
