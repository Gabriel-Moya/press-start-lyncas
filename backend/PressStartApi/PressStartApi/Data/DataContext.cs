using Microsoft.EntityFrameworkCore;
using PressStartApi.Models;

namespace PressStartApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Authentication> Authentication { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>(
                builder =>
                {
                    builder.HasKey(x => x.Id);
                    builder.Property(x => x.Name).HasColumnType("VARCHAR(255)").IsRequired();
                    builder.Property(x => x.Lastname).HasColumnType("VARCHAR(255)").IsRequired();
                    builder.Property(x => x.Email).HasColumnType("VARCHAR(255)").IsRequired();
                    builder.Property(x => x.Phone).HasColumnType("VARCHAR(11)").IsRequired();
                    builder.Property(x => x.BirthDate).HasColumnType("DATE").IsRequired();
                }
            );

            builder.Entity<Authentication>().ToTable("Authentication");
            builder.Entity<Authentication>(
                 builder =>
                 {
                     builder.HasKey(x => x.Id);
                     builder.Property(x => x.UserId);
                     builder.Property(x => x.Password).IsRequired();
                     builder.Property(x => x.IsActive).IsRequired();

                     builder.HasOne(u => u.User)
                        .WithOne(a => a.Authentication)
                        .HasForeignKey<Authentication>(x => x.UserId);
                 }
            );
        }
    }
}
