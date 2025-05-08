using Microsoft.EntityFrameworkCore;
using AntiAge.Data;

namespace AntiAge.Utility
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var dbContext = serviceScope.ServiceProvider.GetService<AntiAgeContext>();
            if (dbContext == null)
            {
                throw new InvalidOperationException("The database context could not be resolved.");
            }
            dbContext.Database.Migrate();
        }
    }
}
