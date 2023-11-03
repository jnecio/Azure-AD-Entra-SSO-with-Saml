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
            var ssoLogin = "https://login.microsoftonline.com/df950190-21a4-4090-9a02-7bb4a5471d57/oauth2/authorize?client_id=0000000c-0000-0000-c000-000000000000&redirect_uri=https%3A%2F%2Faccount.activedirectory.windowsazure.com%2F&response_mode=form_post&response_type=code%20id_token&scope=openid%20profile&state=OpenIdConnect.AuthenticationProperties%3DAQAAAAMAAAAIVGVuYW50SWSrATYwbnVmamV0WHJOT1VDUDZWRVk4azk2RDFBbU05cTR1eWhrRVg0NkE5cVpMR3hIRmJ3TkNQRzhsZjBTSUpManlYNWt2OEY4NHhUdGNfUjB2UmY1dVA0V2lHbXRoek92aWNZUm9aekswc0pmVGRGOTlIV1VvT2Q5U2plNVppZXBOdk5JYTd1WHBoMjBlV0JKa3BWdHB2X2NSNTVSYUZua3ZxMHZ4VEVqei0xQQkucmVkaXJlY3TBAWh0dHBzOi8vYWNjb3VudC5hY3RpdmVkaXJlY3Rvcnkud2luZG93c2F6dXJlLmNvbS9hcHBsaWNhdGlvbnMvdGVzdGZlZGFyYXRlZGFwcGxpY2F0aW9uLmFzcHg_c2VydmljZVByaW5jaXBhbElkPTFlODdkNjNkLTQ0NTctNGRjOC1iZjcxLTJkNDVmNGM3OWZkYSZ0ZW5hbnRJZD1kZjk1MDE5MC0yMWE0LTQwOTAtOWEwMi03YmI0YTU0NzFkNTceT3BlbklkQ29ubmVjdC5Db2RlLlJlZGlyZWN0VXJpwAFsaWxTRmhJeVpOc21WTjJJV0ZtYWxibmpWdWJ4VG9OLW8tX1ZIWlZBSi1VV2tjdXduM1JZTi1peFZ5OWJlNktCMHBLZnlrUmpfUFF3SDBvNmpiLWZONTdpcWZ0dnZ3YkRYOTllRUNMTzZZUTJTdEk5T09PYUdZV25SSDdad1BTZG5HUkFkZTJhMmtLdHdVMlJTaVp2c0dRN1oxSk9PX2Q1MmtkbFpuaEc4VUdFVEFycDRTZ3kta0wtZ2Y3YVh2VDY&nonce=1698997905.T0YOBL8UB64gRzy8o1p8Nw&nux=1&sso_reload=true";

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