using PressStartApi.DTO.Response;
using PressStartApi.Models;

namespace PressStartApi.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> Get();
        Task<User> GetByEmail(string email);
        Task<User> GetById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(User user);
    }
}
