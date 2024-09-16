using Microsoft.AspNetCore.Mvc;

namespace ThemeTest.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
