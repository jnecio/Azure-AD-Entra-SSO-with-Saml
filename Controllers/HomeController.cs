using Microsoft.AspNetCore.Mvc;
using RaadTestSSO.Models;
using System.Diagnostics;

namespace RaadTestSSO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            // Retrieve the target landing page from the session or cookie
            var landingPage = HttpContext?.Session?.GetString("LandingPage") as string;
            var ssoLogin = "https://account.activedirectory.windowsazure.com/applications/testfedaratedapplication.aspx?servicePrincipalId=1e87d63d-4457-4dc8-bf71-2d45f4c79fda&tenantId=df950190-21a4-4090-9a02-7bb4a5471d57";

            if (!string.IsNullOrEmpty(landingPage))
            {
                // Redirect the user to the target landing page
                return RedirectToAction(landingPage, "Home");
            }

            // Redirect to a post-login landing page
            return Redirect(ssoLogin);
            //return View();
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