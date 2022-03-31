using AutoMapper;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Interfaces;
using PressStartApi.Models;

namespace PressStartApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> Login(LoginDTO loginDTO)
        {
            User userLogin = await _loginRepository.Login(loginDTO);
            return _mapper.Map<UserResponseDTO>(userLogin);
        }
    }
}
