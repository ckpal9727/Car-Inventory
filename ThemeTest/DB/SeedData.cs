using Microsoft.AspNetCore.Identity;

namespace ThemeTest.DB
{
	public class SeedData
	{
		public static async Task Initialize(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.CreateScope();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

			// Seed roles if they do not exist
			string[] roleNames = { "Admin", "User", "Driver" };
			foreach (var roleName in roleNames)
			{
				if (!await roleManager.RoleExistsAsync(roleName))
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}

			// Seed admin user if it does not exist
			var adminEmail = "admin@example.com";
			var adminUser = await userManager.FindByEmailAsync(adminEmail);
			if (adminUser == null)
			{
				adminUser = new User
				{
					UserName = adminEmail,
					Email = adminEmail,
					FirstName = "Admin",
					NormalizedUserName = adminEmail.ToUpper(),
					NormalizedEmail = adminEmail.ToUpper(),
					EmailConfirmed = true,
				};
				await userManager.CreateAsync(adminUser, "Admin@123");
				await userManager.AddToRoleAsync(adminUser, "Admin");
			}
		}
	}

}
