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

        [HttpPost("request")]
        public async Task<JsonResult> RequestDonation(DonationRequest donationRequest)
        {
            var isSuccess = await DonationsManager.MakeRequest(donationRequest);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpPut("request")]
        public async Task<JsonResult> UpdateRequest(DonationRequest donationRequest)
        {
            var isSuccess = await DonationsManager.UpdateRequest(donationRequest);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpGet("available")]
        public async Task<JsonResult> GetAvailableDonations()
        {
            var donations = await DonationsManager.GetAvailable();
            return new JsonResult(Ok(donations));
        }

        [HttpPost("submit")]
        public async Task<JsonResult> SubmitFeedback(FeedbackItem feedbackItem)
        {
            var isSuccess = await DonationsManager.AddFeedback(feedbackItem);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpGet("feedback")]
        public async Task<JsonResult> GetAllFeedbacks()
        {
            var donations = await DonationsManager.GetFeedback();
            return new JsonResult(Ok(donations));
        }


    }
}
