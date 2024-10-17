using DynamicForm.DataTransfer.DTOs;
using DynamicForm.Entities.Entities;
using DynamicForm.UI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.UI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{

		private readonly UserManager<AppUser> _userManager;

		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		ResultVM _result = new();

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{

			AppUser appUser = await _userManager.FindByNameAsync(userLoginDto.Username);

			if (appUser == null)
			{

				_result.Message = "Kullanıcı bulunamadı !";

			}
			else
			{

				var result = await _signInManager.PasswordSignInAsync(appUser, userLoginDto.Password, false, false);

				if (result.Succeeded)
				{

					_result.Status = true;
					_result.RedirectUrl = "/Form";

				}
				else
				{

					_result.Status = false;
					_result.Message = "E-Posta veya Parola Hatalı !";

				}

			}

			return Json(_result);

		}

		public async Task<IActionResult> Logout()
		{

			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Login");

		}
	}
}
