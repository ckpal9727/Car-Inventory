using Microsoft.AspNetCore.Identity;

namespace ThemeTest.DB
{
	public class User:IdentityUser
	{
		public string FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
