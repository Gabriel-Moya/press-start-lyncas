using PressStartApi.DTO.Request;
using PressStartApi.Models;

namespace PressStartApi.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> Login(LoginDTO loginDTO);
    }
}
