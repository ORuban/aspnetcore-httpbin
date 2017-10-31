using Microsoft.AspNetCore.Mvc;

namespace HttpBin.Server.Controllers
{
    public class StatusController : Controller
    {
        [HttpGet("/status/{code}")]
        public IActionResult Status(int code)
        {
            return new StatusCodeResult(code);
        }
    }
}