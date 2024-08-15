using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.Models;

namespace WarehouseManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;

        public AccountController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewData)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewData);
            }

            await _signInManager.PasswordSignInAsync(loginViewData.UserName, loginViewData.Password, false, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewData)
        {
            if(!ModelState.IsValid)
            {
                return View(registerViewData);
            }

            var newUser = new UserModel
            {
                FirstName = registerViewData.FirstName,
                LastName = registerViewData.LastName,
                UserName = registerViewData.UserName
            };

            await _userManager.CreateAsync(newUser, registerViewData.Password);

            return RedirectToAction("Index", "Home");
        }
    }
}
