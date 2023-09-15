using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using WebAPI_Studies.api.Domain.Model;

namespace WebAPI_Studies.api.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<UserModel> User { get; set; }

        public static void SeedData(ConnectionContext context)
        {
            if (!context.User.Any(p => p.username == "admin"))
            {
                context.User.Add(new UserModel { username = "admin", password = "gvmmBEBwQkdr8yjj9dr4CA==:$2a$12$XOSAn4JoYnkOc46y6aFJTetWsMGh0Kge8a4rUhQgpcoaE3jENmj5a" });
                context.SaveChanges();
            }
        }
    }
}
