using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Models;
using MyApp.BAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace MyApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserDto req)
        {
            UserDto res = new UserDto();
            res = LoginService.Login(req.UserName, req.Password);
            if (res.Flag==0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(res);
            }
           
        }
        public IActionResult Logout()
        {
            // Clear all session data
            HttpContext.Session.Clear();

            // Remove the authentication cookie
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the login page or any other page
            return RedirectToAction("Login", "Login");
        }
    }
}
