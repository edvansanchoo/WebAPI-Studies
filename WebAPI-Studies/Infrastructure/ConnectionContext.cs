using Microsoft.EntityFrameworkCore;
using WebAPI_Studies.Models;

namespace WebAPI_Studies.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                "Server=127.0.0.1;" +
                "Database=webapi;" +
                "User Id=sa;" +
                "Password=Pass@word;" +
                "Trusted_Connection=False;" +
                "Encrypt=false;" +
                "TrustServerCertificate=True"); ;
        }
    }
}
