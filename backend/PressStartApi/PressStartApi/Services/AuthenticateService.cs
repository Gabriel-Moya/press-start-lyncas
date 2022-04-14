using AutoMapper;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Interfaces;

namespace PressStartApi.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        public readonly IUserService _authService;
        public IEnumerable<LoginDTO>? usersResponse;

        public AuthenticateService(ILoginService loginService, IMapper mapper, IUserService authService)
        {
            _authService = authService;
            _loginService = loginService;
            _mapper = mapper;
        }

        public async Task<LoginDTO> Authenticate(LoginDTO loginDTO)
        {
            UserResponseDTO user = await _loginService.Login(loginDTO);

            return _mapper.Map<LoginDTO>(user);
        }
    }
}
