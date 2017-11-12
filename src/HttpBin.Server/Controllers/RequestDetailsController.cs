using HttpBin.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpBin.Server.Controllers
{
    public class RequestDetailsController : Controller
    {
        [HttpGet("/get")]
        public IActionResult Get()
        {
            string requestUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";

            var result = new {
                args = Request.Query.ToJObject(),
                headers = Request.Headers.ToJObject(),
                url = requestUrl,
                cookies = Request.Cookies.ToJObject()
            };

            return new JsonResult(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}