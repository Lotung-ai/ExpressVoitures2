using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressVoitures.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Create roles if they don't exist
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Failed to create role {roleName}: {roleResult.Errors.FirstOrDefault()?.Description}");
                    }
                }
            }

            // Create admin user if it doesn't exist
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123456";
            var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };

            var user = await userManager.FindByEmailAsync(adminEmail);

            if (user == null)
            {
                var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdmin.Succeeded)
                {
                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");
                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add admin user to Admin role: {addToRoleResult.Errors.FirstOrDefault()?.Description}");
                    }
                }
                else
                {
                    throw new Exception($"Failed to create admin user: {createAdmin.Errors.FirstOrDefault()?.Description}");
                }
            }
            else
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains("Admin"))
                {
                    var addToRoleResult = await userManager.AddToRoleAsync(user, "Admin");
                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add existing user to Admin role: {addToRoleResult.Errors.FirstOrDefault()?.Description}");
                    }
                }
            }
            // Trouver l'utilisateur admin_user
            adminUser = await userManager.FindByEmailAsync("admin@example.com");

            if (adminUser != null)
            {
                // Trouver le rôle "Admin"
                var adminRole = await roleManager.FindByNameAsync("Admin");

                if (adminRole == null)
                {
                    throw new Exception("Role 'Admin' not found.");
                }

                // Vérifier si l'utilisateur n'a pas déjà le rôle
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    // Attribuer le rôle "Admin" à l'utilisateur
                    var addToRoleResult = await userManager.AddToRoleAsync(adminUser, "Admin");

                    if (!addToRoleResult.Succeeded)
                    {
                        throw new Exception($"Failed to add admin user to Admin role: {addToRoleResult.Errors.FirstOrDefault()?.Description}");
                    }
                }
            }
            else
            {
                throw new Exception("User 'admin@example.com' not found.");
            }
        }
    }
}
