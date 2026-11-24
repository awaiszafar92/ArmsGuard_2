using ARMSGUARD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ARMSGUARD.Data;

public sealed class DbInitializer(
    ApplicationDbContext dbContext,
    RoleManager<IdentityRole> roleManager,
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration,
    ILogger<DbInitializer> logger)
{
    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);

        foreach (var roleName in new[] { IdentityRoles.Administrator, IdentityRoles.User })
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"Unable to create the {roleName} role: {string.Join(", ", result.Errors.Select(error => error.Description))}");
                }
            }
        }

        var adminEmail = configuration["BootstrapAdmin:Email"];
        var adminPassword = configuration["BootstrapAdmin:Password"];
        if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
        {
            logger.LogInformation("Administrator seeding was skipped. Configure BootstrapAdmin:Email and BootstrapAdmin:Password to provision an administrator.");
            return;
        }

        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin is null)
        {
            admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FullName = "ArmsGuard Administrator"
            };
            var result = await userManager.CreateAsync(admin, adminPassword);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unable to create the configured administrator: {string.Join(", ", result.Errors.Select(error => error.Description))}");
            }
        }

        if (!await userManager.IsInRoleAsync(admin, IdentityRoles.Administrator))
        {
            var result = await userManager.AddToRoleAsync(admin, IdentityRoles.Administrator);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unable to assign the Administrator role: {string.Join(", ", result.Errors.Select(error => error.Description))}");
            }
        }
    }
}
