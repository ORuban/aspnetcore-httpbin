using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace HttpBin.Server.Controllers
{
    public class RegirectController : Controller
    {
        [HttpGet("/redirect-to")]
        public IActionResult RedirectTo([FromQuery] string url)
        {
            return Redirect(url);
        }

        [HttpGet("/temporary-redirect-to")]
        public ActionResult TemporaryRedirectTo([FromQuery] string url)
        {
            Response.Headers.Add(HeaderNames.Location, url);
            return new StatusCodeResult(307);
        }

        [HttpGet("/permanent-redirect-to")]
        public ActionResult PermanentRedirectTo([FromQuery] string url, bool preserveMethod = false)
        {
            if (preserveMethod) return RedirectPermanentPreserveMethod(url);

            return RedirectPermanent(url);

        }

        [HttpGet("/relative-redirects/{number}")]
        public IActionResult RelativeRedirects([FromRoute] int number)
        {
            if (number <= 1) return Redirect("/get");

            return Redirect($"/relative-redirects/{number-1}");
        }  

        [HttpGet("/relative-redirects/{number}")]
        public IActionResult TemporaryRedirects([FromRoute] int number)
        {
            if (number <= 1) return Redirect("/get");

            return Redirect($"/relative-redirects/{number-1}");
        }   

        [HttpGet("/permanent-redirects/{number}")]
        public IActionResult PermanentRedirects([FromRoute] int number)
        {
            if (number <= 1) return RedirectPermanent("/get");

            return RedirectPermanent($"/permanent-redirects/{number-1}");
        }   
    }
}