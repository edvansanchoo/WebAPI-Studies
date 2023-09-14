using Microsoft.EntityFrameworkCore;
using WebAPI_Studies.api.Infrastructure;

namespace WebAPI_Studies.api.Application.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInicialization(this IApplicationBuilder app )
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDB = serviceScope.ServiceProvider.GetService<ConnectionContext>();
                serviceDB.Database.EnsureCreated();
                //serviceDB.Database.Migrate();
                ConnectionContext.SeedData(serviceDB);
            }
        }
    }
}
