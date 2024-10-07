using Lab1.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab1.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed Roles
            var roles = new[] { "Manager", "Employee" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Users
            await CreateUser(userManager, "manager@example.com", "Manager");
            await CreateUser(userManager, "employee@example.com", "Employee");
        }

        private static async Task CreateUser(UserManager<ApplicationUser> userManager, string email, string role)
        {
            if (await userManager.FindByEmailAsync(email) == null)
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = role + "FirstName",
                    LastName = role + "LastName",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "@Password123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
