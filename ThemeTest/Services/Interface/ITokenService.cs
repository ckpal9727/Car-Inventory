using ThemeTest.DB;

namespace ThemeTest.Services.Interface
{
	public interface ITokenService
	{
		Task<string> GenerateToken(User user);
	}
}
