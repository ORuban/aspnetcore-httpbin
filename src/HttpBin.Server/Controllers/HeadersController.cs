using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HttpBin.Server.Controllers
{
    public class HeadersController : Controller
    {
        [HttpGet("/headers")]
        public IActionResult Headers()
        {
            return new JsonResult(
                new
                {
                    headers = HttpContext.Request.Headers
                }, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}