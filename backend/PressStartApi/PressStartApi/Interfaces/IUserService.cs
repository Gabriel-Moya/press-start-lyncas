using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> Get();
        Task<User> GetByEmail(string email);
        Task<UserResponseDTO> GetById(int id);
        Task<UserResponseDTO> AddUser(DTO.Request.SendUserDTO user);
        Task<UserResponseDTO> UpdateUser(int id, DTO.Request.SendUserDTO user);
        Task DeleteUser(int id);
    }
}
