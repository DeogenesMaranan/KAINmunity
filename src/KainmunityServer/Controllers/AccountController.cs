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
            var loginResult = await AccountManager.VerifyLogin(loginDetails);

            if (!loginResult.IsAuthorized ?? false)
            {
                return new JsonResult(Unauthorized());
            }

            return new JsonResult(new
            {
                StatusCode = StatusCodes.Status200OK,
                UserId = loginResult.UserId,
                AccountType = loginResult.AccountType,
            });
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

        [HttpGet("info/{userId}")]
        public async Task<JsonResult> GetAccount(string userId)
        {
            var res = await AccountManager.GetAccountInfo(Convert.ToInt32(userId));
            return new JsonResult(Ok(res));
        }

        [HttpGet("requests/{userId}")]
        public async Task<JsonResult> GetRequestHistory(string userId)
        {
            var res = await AccountManager.GetRequestHistory(Convert.ToInt32(userId));
            return new JsonResult(Ok(res));
        }

        [HttpGet("donations/{userId}")]
        public async Task<JsonResult> GetDonationHistory(string userId)
        {
            var res = await AccountManager.GetDonationHistory(Convert.ToInt32(userId));
            return new JsonResult(Ok(res));
        }
    }
}
