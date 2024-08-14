using Microsoft.AspNetCore.Mvc;
using WarehouseManagementSystem.Models;

namespace WarehouseManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewData)
        {
            if(!ModelState.IsValid)
            {
                return View(loginViewData);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
