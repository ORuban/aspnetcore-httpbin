using HttpBin.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HttpBin.Server.Controllers
{
    public class CookiesController : Controller
    {
        [HttpGet("/cookies")]
        public IActionResult Get()
        {
            return new JsonResult(
                new
                {
                    cookies = Request.Cookies.ToJObject()
                }, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        [HttpGet("/cookies/set")]
        public IActionResult Set()
        {
            foreach (var parameter in Request.Query)
            {
                Response.Cookies.Append(parameter.Key, parameter.Value);
            }

            return Redirect("/cookies");
        }


        [HttpGet("/cookies/delete")]
        public IActionResult Delete()
        {
            foreach (var parameter in Request.Query)
            {
                Response.Cookies.Delete(parameter.Key);
            }

            return Redirect("/cookies");
        }
    }
}