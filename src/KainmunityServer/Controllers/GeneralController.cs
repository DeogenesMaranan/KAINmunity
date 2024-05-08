using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KainmunityServer.Controllers
{
    [Route("api")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        [HttpGet("ping")]
        public async Task<JsonResult> Ping()
        {
            return new JsonResult(Ok());
        }
    }
}
