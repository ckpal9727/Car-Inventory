using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThemeTest.DB;
using ThemeTest.Models;
using ThemeTest.Services.Interface;

namespace ThemeTest.Controllers
{
    public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ITokenService _tokenService;

		public AccountController(UserManager<User> userManager,
							 SignInManager<User> signInManager,
							 ITokenService tokenService)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
	

		[HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the view with validation errors
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
			await _signInManager.SignInAsync(user, isPersistent: false);

			var token = await _tokenService.GenerateToken(user);
            HttpContext.Session.SetString("AuthToken", token);
            return RedirectToAction("Index", "Home");
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			//await HttpContext.SignOutAsync();
			await _signInManager.SignOutAsync();
			//await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

	}
}
