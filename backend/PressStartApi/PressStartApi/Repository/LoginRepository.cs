using PressStartApi.DTO.Request;
using PressStartApi.Interfaces;
using PressStartApi.Models;

namespace PressStartApi.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DataContext _context;

        public LoginRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            User user = await _context.Set<User>()
                                .Include(x => x.Authentication)
                                .FirstAsync(x => x.Email == loginDTO.Email &&
                                x.Authentication.Password == loginDTO.Password);

            return user;
        }
    }
}
