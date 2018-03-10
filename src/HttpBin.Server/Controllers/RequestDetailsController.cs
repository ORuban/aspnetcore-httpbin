using HttpBin.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace HttpBin.Server.Controllers
{
    public class RequestDetailsController : Controller
    {
        [HttpGet("/get")]
        [HttpPost("/post")]
        [HttpPut("/put")]
        [HttpPatch("/patch")]
        public IActionResult Get()
        {
            string requestUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";
            
            var result = new Dictionary<string, object>();
            result.Add("args", Request.Query.ToJObject());
            result.Add("headers", Request.Headers.ToJObject());
            result.Add("url", requestUrl);
            result.Add("cookies", Request.Cookies.ToJObject());

            if (Request.Method != "GET")
            {
                result.Add("form-data", Request.Form.ToJObject());
                result.Add("files", Request.Form.Files.ToJObject());
            }
            
            return new JsonResult(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}