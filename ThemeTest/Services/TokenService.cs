using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ThemeTest.DB;
using ThemeTest.Services.Interface;

namespace ThemeTest.Services
{
	public class TokenService:ITokenService
	{
		private readonly UserManager<User> _userManager;

		public TokenService(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<string> GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("SuperSecretKey12345678901234567890");
			var userRoles = await _userManager.GetRolesAsync(user);

			var claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, user.UserName)
		};

			foreach (var role in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddHours(1),
				Issuer = "YourIssuer",
				Audience = "YourAudience",
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
