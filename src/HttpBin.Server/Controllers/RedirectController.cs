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

        [HttpGet("/temporaryredirect-to")]
        public ActionResult TemporaryRedirectTo([FromQuery] string url)
        {
            Response.Headers.Add(HeaderNames.Location, url);
            return new StatusCodeResult(307);
        }
    }
}