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
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpGet("request")]
        public async Task<JsonResult> GetRequests()
        {
            var res = await DonationsManager.GetRequests();
            return new JsonResult(Ok(res)); 
        }

        [HttpGet("request/{donationId}")]
        public async Task<JsonResult> GetAssociatedRequests(int donationId)
        {
            var res = await DonationsManager.GetAssociatedRequests(donationId);
            return new JsonResult(Ok(res));
        }

        [HttpPost("request")]
        public async Task<JsonResult> RequestDonation(DonationRequest[] donationRequests)
        {
            if (!Request.Headers.TryGetValue("User-Id", out var headerValue))
            {
                return new JsonResult(BadRequest());
            }

            int userId = Convert.ToInt32(headerValue[0]);

            for (int i = 0; i < donationRequests.Length; i++)
            {
                donationRequests[i].RequesterId = userId;
                donationRequests[i].Status = "Pending";
            }

            var isSuccess = await DonationsManager.MakeRequest(donationRequests);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpPut("request")]
        public async Task<JsonResult> UpdateRequests(DonationRequest[] donationRequests)
        {
            var isSuccess = await DonationsManager.UpdateRequests(donationRequests);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpGet("available")]
        public async Task<JsonResult> GetAvailableDonations()
        {
            var donations = await DonationsManager.GetAvailable();
            return new JsonResult(Ok(donations));
        }

        [HttpGet("leaderboard")]
        public async Task<JsonResult> GetLeaderboard()
        {
            var donations = await DonationsManager.FetchLeaderboard();
            return new JsonResult(Ok(donations));
        }
    }
}
