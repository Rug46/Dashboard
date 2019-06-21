using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Dashboard.Helpers;

namespace Dashboard.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Login");
            }

            if (Passwords.PasswordCorrect(username, password))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string email, int question1, int question2, int question3, string answer1, string answer2, string answer3)
        {
            if(!Account.RegisterParent(username, password, email, question1, question2, question3, answer1, answer2, answer3))
            {
                return RedirectToAction("Register");
            }

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reset()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reset(string username, string email)
        {
            if (!SecurityQuestion.UsernameEmailMatch(username, email))
            {
                TempData["Error"] = "Username and Email don't match";

                return View();
            }

            return RedirectToAction("ResetAuth", new { username, email });
        }

        [HttpGet]
        public IActionResult ResetAuth(string username, string email)
        {
            if (username == "" || username == null || email == "" || email == null)
            {
                return RedirectToAction("Reset");
            }

            TempData["username"] = username;
            TempData["email"] = email;

            return View();
        }

        [HttpPost]
        public IActionResult ResetAuth(string username, string email, string answer1, string answer2, string answer3)
        {
            var token = Account.GenerateResetToken(username, email, answer1, answer2, answer3);

            if (token == null)
            {
                return RedirectToAction("Reset");
            }

            return RedirectToAction("ResetToken", new { token });
        }

        [HttpGet]
        public IActionResult ResetToken(string token)
        {
            if (token == "" || token == null)
            {
                return RedirectToAction("Reset");
            }

            TempData["Token"] = token;

            return View();
        }

        [HttpPost]
        public IActionResult ResetToken(string token, string password, string confirm)
        {
            var userid = Account.GetTokenUserId(token);

            if (userid <= 0)
            {
                return RedirectToAction("Reset");
            }

            if (password != confirm)
            {
                return RedirectToAction("ResetToken", new { token });
            }

            Account.ResetPassword(token, password);

            return RedirectToAction("Login");
        }
    }
}