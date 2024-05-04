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
            var isSuccess = await AccountManager.VerifyLogin(loginDetails);

            if (isSuccess)
            {
                return new JsonResult(Ok());
            }
            else
            {
                return new JsonResult(Unauthorized());
            }
        }

        [HttpPost("signup")]
        public async Task<JsonResult> RegisterAccount(UserDetails userDetails)
        {
            var isSuccess = await AccountManager.CreateAccount(userDetails);

            if (isSuccess)
            {
                return new JsonResult(Ok());
            }
            else
            {
                return new JsonResult(Unauthorized());
            }
        }

        [HttpPut("edit")]
        public async Task<JsonResult> EditAccount(UserDetails userDetails)
        {
            return new JsonResult(Ok(userDetails));
        }
    }
}
