using PressStartApi.DTO;
using PressStartApi.DTO.Request;
using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDTO>> Get();
        Task<User> GetByEmail(string email);
        Task<UserResponseDTO> GetById(int id);
        Task<UserResponseDTO> AddUser(InsertUserDTO user);
        Task<UserResponseDTO> UpdateUser(int id, UpdateUserDTO user);
        Task DeleteUser(int id);
    }
}
