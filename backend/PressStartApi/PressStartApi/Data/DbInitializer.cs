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
                    Name = "Root",
                    Lastname = "Lyncas",
                    Email = "root@lyncas.net",
                    Phone = "47999998888",
                    BirthDate = DateTime.Now,
                });
            _modelBuilder.Entity<Authentication>().HasData(
                new Authentication()
                {
                    Id = 1,
                    Password = "1d123173e5522fb682fe5b0aedd5fd9ea5c2769ff738991c08c10f79f80e9c50",
                    IsActive = true,
                    UserId = 1,
                });
        }
    }
}