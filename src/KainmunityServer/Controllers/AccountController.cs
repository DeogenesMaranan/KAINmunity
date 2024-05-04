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
        public JsonResult loginAccount(LoginDetails loginDetails)
        {
            return new JsonResult(Ok(loginDetails));
        }

        [HttpPost("signup")]
        public JsonResult registerAccount(UserDetails userDetails)
        {
            return new JsonResult(Ok(userDetails));
        }

        [HttpPut("edit")]
        public JsonResult editAccount(UserDetails userDetails)
        {
            return new JsonResult(Ok(userDetails));
        }
    }
}
