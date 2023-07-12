using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users {get;set;}
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() 
            {
                Guid = Guid.NewGuid(),
                Login = "login0",
                UserName = "userName0",
                Email = "test0@mail.ru",
                Country = "Russia"
            });
        }
    }
}