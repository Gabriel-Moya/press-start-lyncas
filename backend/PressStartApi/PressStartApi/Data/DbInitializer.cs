using PressStartApi.Models;

namespace PressStartApi.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void seed()
        {
            _modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Name = "admin",
                    Lastname = "admin",
                    Email = "admin@lyncas.net",
                    Phone = "67998456580",
                    BirthDate = DateTime.Now,
                });
            _modelBuilder.Entity<Authentication>().HasData(
                new Authentication()
                {
                    Id = 1,
                    Password = "lyncas123",
                    IsActive = true,
                    UserId = 1,
                });
        }
    }
}
