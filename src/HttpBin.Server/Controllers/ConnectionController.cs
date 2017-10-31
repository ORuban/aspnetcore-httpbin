using Microsoft.AspNetCore.Mvc;

namespace HttpBin.Server.Controllers
{
    public class ConnectionController : Controller
    {
        [HttpGet("/ip")]
        public IActionResult RemoteIp(int code)
        {
            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
            return new JsonResult(new { origin = remoteIpAddress.ToString() });
        }
    }
}