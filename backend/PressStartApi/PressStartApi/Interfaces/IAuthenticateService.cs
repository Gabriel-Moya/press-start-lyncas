using PressStartApi.DTO.Request;

namespace PressStartApi.Interfaces
{
    public interface IAuthenticateService
    {
        Task<LoginDTO> Authenticate(LoginDTO loginDTO);
        Task<IEnumerable<LoginDTO>> Get();
    }
}
