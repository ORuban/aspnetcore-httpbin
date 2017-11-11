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
            var request = HttpContext.Request;
            
            string requestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";

            var result = new {
                args = request.Query.ToJObject(),
                headers = request.Headers.ToJObject(),
                url = requestUrl,
                cookies = request.Cookies.ToJObject()
            };

            return new JsonResult(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}