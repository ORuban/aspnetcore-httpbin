using HttpBin.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpBin.Server.Controllers
{
    public class HeadersController : Controller
    {
        [HttpGet("/user-agent")]
        public IActionResult UserAgent()
        {
            var headers = Request.Headers;
            string userAgent = string.Empty;

            if (headers.ContainsKey("User-Agent"))
            {
                userAgent = headers["User-Agent"].ToString();
            }

            var obj = new JObject();
            obj.Add("user-agent", userAgent);

            return new JsonResult(obj, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("/headers")]
        public IActionResult Headers()
        {
            return new JsonResult(
                new
                {
                    headers = Request.Headers.ToJObject()
                }, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}