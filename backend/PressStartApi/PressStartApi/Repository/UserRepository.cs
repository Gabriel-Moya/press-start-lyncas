using PressStartApi.Interfaces;
using PressStartApi.Models;

namespace PressStartApi.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Get()
        {
            List<User> users = await _context.Set<User>()
                                             .Include(x => x.Authentication)
                                             .AsNoTracking()
                                             .ToListAsync();

            return users;
        }

        public async Task<User?> GetByEmail(string email)
        {
            User? user = await _context.Set<User>()
                                .Include(x => x.Authentication)
                                .SingleOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> GetById(int id)
        {
            User user = await _context.Set<User>()
                                .Include(x => x.Authentication)
                                .SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Set<User>().Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {            
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
