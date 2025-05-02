using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<AntiAgeContext>();
            context.Database.Migrate();
        }
    }
}
