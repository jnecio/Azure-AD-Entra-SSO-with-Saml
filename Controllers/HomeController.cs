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
            var ssoLogin = "https://login.microsoftonline.com/df950190-21a4-4090-9a02-7bb4a5471d57/saml2?SAMLRequest=jZFPT8JAEMW%2FSrN3%2Bh9ZN22TQiEhYmIAPXgbyxiatLt1Z4rGT%2B9SwoloPM5k5s37vckIurZX5cBHvcWPAYm9r67VlIvBamWAGlIaOiTFtdqVjxsV%2B6HqkOEADMJbV7lYybSSUpZlMk%2FTRTSXaZrMpmW6lHEUVvdL4b2gpcboXLhlt0M04FoTg2bXCuNkEkWTMNmHMxVFanrnyzB%2BPc89AVFzwly8Q0sovJIILTulhdE0dGh3aE9Njc%2FbTS6OzD2pILAAB3YgPnwPFj%2FxjRpX%2Bho5ONMGv4mIC7kaI%2Fmbv7eGTW1a4a2MrXGM72qyyEY%2B%2B58c4WpFFFvneucu741pHxrOgotKkQW3Lyp%2BAA%3D%3D";

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