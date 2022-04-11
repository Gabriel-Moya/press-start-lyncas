using AutoMapper;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Functions;
using PressStartApi.Interfaces;
using PressStartApi.Models;

namespace PressStartApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> Login(LoginDTO loginDTO)
        {
            User user = await _userService.GetByEmail(loginDTO.Email);
            string hashedPassword = HashPassword.HashingPassword(loginDTO.Password);

            if (hashedPassword == user.Authentication.Password)
            {
                return _mapper.Map<UserResponseDTO>(user);
            }

            throw new BadHttpRequestException("Credenciais inválidas", 401);
        }
    }
}
