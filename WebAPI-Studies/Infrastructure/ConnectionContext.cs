using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI_Studies.Domain.Model;

namespace WebAPI_Studies.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ConnectionContext()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DB_webapi")); ;
        }
    }
}
