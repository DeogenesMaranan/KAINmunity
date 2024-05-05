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
            var userId = await AccountManager.VerifyLogin(loginDetails);

            if (userId != -1)
            {
                return new JsonResult(new
                {
                    StatusCode = StatusCodes.Status200OK,
                    UserId = userId,
                });
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
            if (!Request.Headers.TryGetValue("User-Id", out var headerValue))
            {
                return new JsonResult(NotFound());
            }

            int userId = Convert.ToInt32(headerValue[0]);

            bool isSuccess = await AccountManager.EditAccount(userId, userDetails);
            return new JsonResult(isSuccess ? Ok() : NotFound());
        }

        [HttpGet("info")]
        public async Task<JsonResult> GetAccount()
        {
            if (!Request.Headers.TryGetValue("User-Id", out var headerValue))
            {
                return new JsonResult(NotFound());
            }

            int userId = Convert.ToInt32(headerValue[0]);

            var res = await AccountManager.GetAccountInfo(userId);
            return new JsonResult(Ok(res));
        }
    }
}
