using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Saml2;
//using Microsoft.IdentityModel.Tokens.Saml2;
//using Sustainsys.Saml2.Tokens;
using System.Xml;

namespace RaadTestSSO.Controllers
{
    public class SamlAssertionConsumerServiceController : Controller
    {
        /*[HttpPost]
        public IActionResult Post()
        {
            // Handle and process the incoming SAML assertion here
            // Validate the assertion, create or update the user session, and perform application-specific actions

            // Return a response as needed

            return View();
        }*/

        [HttpPost]
        [Route("saml/AssertionConsumer")]
        public ActionResult SamlAcs()
        {
            // Get the SAML Response from the form data
            string samlResponse = Request.Form["SAMLResponse"];

            // Process and validate the SAML response
            try
            {
                // Load the SAML response into an XML document
                XmlDocument samlResponseXml = new XmlDocument();
                samlResponseXml.LoadXml(samlResponse);

                // Perform SAML response validation, such as checking the signature
                // You may need to configure your SAML library for this step

                // Extract the SAML assertion
                // TODO: SecurityToken samlAssertion = /* Extract and validate the SAML assertion here */;

                // Log the user in or perform further processing
                // Typically, you would extract user information from the SAML assertion
                // and use it for authentication and authorization.

                // Example: You can access user attributes from the SAML assertion
                // TODO: string? username = samlAssertion as Saml2SecurityToken;

                // Example: Log the user in
                //FormsAuthentication.SetAuthCookie(username, false);

                // Redirect to a post-login landing page
                return RedirectToAction("Welcome", "Home");
            }
            catch (Exception ex)
            {
                // Handle SAML response validation or processing errors
                // You should implement proper error handling and logging here.
                return View("Error");
            }
        }

        [HttpGet]
        [Route("saml/Login")]
        public ActionResult SamlLogin()
        {
            try
            {

                // Redirect to a post-login landing page
                return RedirectToAction("Welcome", "Home");
            }
            catch (Exception ex)
            {
                // Handle SAML response validation or processing errors
                // You should implement proper error handling and logging here.
                return View("Error");
            }
        }

    }
}
