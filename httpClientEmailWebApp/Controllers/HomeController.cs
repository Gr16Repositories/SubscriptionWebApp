using httpClientEmailWebApp.Models;
using httpClientEmailWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace httpClientEmailWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;

        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        //comment 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // when user click supsucription button
        public IActionResult CreateSubscription()
        {
            Email newEmail = new()
            {
                SubscriberEmail = "fadi.abji@hotmail.com",
                SubscriptionTypeName = "Basic",
                SubscriberName = "Alpha Team"
            };
            TempData["ShowMessage"]  = SendConfirmation(newEmail);
            return RedirectToAction("Privacy");
            //return RedirectToAction("UserPage", "User");
        }

        public string SendConfirmation(Email newEmail)
        {
            return _emailService.SendSubscriptionEmail(newEmail).Result;
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}