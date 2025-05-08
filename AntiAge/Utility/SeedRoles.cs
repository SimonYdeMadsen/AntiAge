using AntiAge.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace AntiAge.Utility
{
    public class SeedRoles
    {
        private enum Roles { Admin = 0, User = 1, Manager = 2 };

        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            // Seed roles
            await SeedAsync(roleManager);

            // Seed admin user
            string adminEmail = "admin@email.com";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User { UserName = adminEmail, Email = adminEmail };
                var createResult = await userManager.CreateAsync(adminUser, "Password123!");
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                }
            }
        }


        private static async Task SeedAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            

            foreach (Roles role in Enum.GetValues(typeof(Roles)))
            {
                var roleExists = await roleManager.RoleExistsAsync(role.ToString());
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = role.ToString() });
                }
            }
        }
    }
}
