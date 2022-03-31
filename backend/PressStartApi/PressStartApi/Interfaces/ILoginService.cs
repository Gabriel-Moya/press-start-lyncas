using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;

namespace PressStartApi.Interfaces
{
    public interface ILoginService
    {
        Task<UserResponseDTO> Login(LoginDTO loginDTO);
    }
}
