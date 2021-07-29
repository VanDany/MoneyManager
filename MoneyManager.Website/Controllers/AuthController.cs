using Microsoft.AspNetCore.Mvc;
using Models.Client.Data;
using Models.Client.Repositories;
using MoneyManager.Website.Infrastructure.Security;
using MoneyManager.Website.Infrastructure.Session;
using MoneyManager.Website.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly ISessionManager _sessionManager;
        public AuthController(IAuthRepository authRepository, ISessionManager sessionManager)
        {
            _authRepository = authRepository;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            User user = _authRepository.Login(form.Email, form.Password);

            if (user is null)
            {
                ModelState.AddModelError("", "e-mail ou mot de passe invalide");
                return View(form);
            }
            _sessionManager.User = new UserSession() { Id = user.Id, Username = user.Username, EmailAddress = user.EmailAddress, Token = user.Token };

            return RedirectToAction("Index", "Category");
        }

        [AnonymousRequired]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid)
                return View(form);
            //Why ?
            _authRepository.Register(new User(form.Username, form.Email, form.Password, 0, 1));
            return RedirectToAction("Login");
        }

        [AuthRequired]
        public IActionResult Logout()
        {
            _sessionManager.Clear();
            return RedirectToAction("Login");
        }
    }
}
