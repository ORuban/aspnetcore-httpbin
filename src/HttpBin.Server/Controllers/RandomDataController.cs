using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HttpBin.Server.Controllers
{
    public class RandomDataController : Controller
    {
        [HttpGet("/uuid")]
        public IActionResult UUID()
        {
            return new JsonResult(new { uuid = Guid.NewGuid() },
                                  new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}