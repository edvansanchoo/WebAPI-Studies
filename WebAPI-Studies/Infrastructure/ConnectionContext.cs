using Microsoft.EntityFrameworkCore;
using WebAPI_Studies.Models;

namespace WebAPI_Studies.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DB_webapi")); ;
        }
    }
}
