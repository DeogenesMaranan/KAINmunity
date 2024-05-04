using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KainmunityServer.Models;
using KainmunityServer.DataAccess;

namespace KainmunityServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<JsonResult> LoginAccount(LoginDetails loginDetails)
        {
            return new JsonResult(Ok(loginDetails));
        }

        [HttpPost("signup")]
        public async Task<JsonResult> RegisterAccount(UserDetails userDetails)
        {
            return new JsonResult(Ok(userDetails));
        }

        [HttpPut("edit")]
        public async Task<JsonResult> EditAccount(UserDetails userDetails)
        {
            return new JsonResult(Ok(userDetails));
        }
    }
}
