using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneyManager.Website.Infrastructure.Session;
using MoneyManager.Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, ISessionManager sessionManager)
        {
            _logger = logger;
            _sessionManager = sessionManager;
        }

        public IActionResult Index()
        {
            if (_sessionManager.User == null)
            {
                return RedirectToAction("Index", "Auth"); 
            }
            else
            {
                return RedirectToAction("Index", "Transaction");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
