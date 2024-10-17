using DynamicForm.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.UI.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{

		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> CreateUser()
		{

			AppUser appUser = new AppUser
			{
				UserName = "erdinc",
				Email = "erdinc@hotmail.com"
			};

			await _userManager.CreateAsync(appUser, "12345");

			return RedirectToAction("Index", "Login");

		}

	}
}
