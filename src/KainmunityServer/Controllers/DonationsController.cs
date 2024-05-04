using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KainmunityServer.DataAccess;
using KainmunityServer.Models;

namespace KainmunityServer.Controllers
{
    [Route("api/donations")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        [HttpPost("contribute")]
        public async Task<JsonResult> ContributeDonation(DonationItem donationItem)
        {
            var isSuccess = await DonationsManager.AddDonation(donationItem);

            if (isSuccess)
            {
                return new JsonResult(Ok());
            }
            else
            {
                return new JsonResult(Unauthorized());
            }
        }
    }
}
