using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ThemeTest.DB
{
	public class DataBaseContext : IdentityDbContext<User>
	{
		public DataBaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);


			// Seed roles
			
			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Driver", NormalizedName = "DRIVER" }
			);

			// Seed admin user
			var hasher = new PasswordHasher<User>();
			builder.Entity<User>().HasData(
				new User
				{
					Id = Guid.NewGuid().ToString(),
					UserName = "admin@example.com",
					FirstName="Admin",
					NormalizedUserName = "ADMIN@EXAMPLE.COM",
					Email = "admin@example.com",
					NormalizedEmail = "ADMIN@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = hasher.HashPassword(null, "Admin@123")
				}
			);
		}
	}
}
