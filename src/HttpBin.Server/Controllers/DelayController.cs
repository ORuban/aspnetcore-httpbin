using HttpBin.Server.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace HttpBin.Server.Controllers
{
    public class DelayController : Controller
    {
        [HttpGet("/delay/{ms}")]
        public async Task<IActionResult> Get(int ms)
        {
            await Task.Delay(ms);

            return Redirect("/get");
        }
    }
}