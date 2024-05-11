using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KainmunityServer.DataAccess;
using KainmunityServer.Models;

namespace KainmunityServer.Controllers
{
    [Route("api/logistics")]
    [ApiController]
    public class LogisticsController : ControllerBase
    {
        [HttpGet("request")]
        public async Task<JsonResult> GetAcceptedRequest()
        {
            var accepted = await LogisticManager.FetchAcceptedRequest();
            return new JsonResult(Ok(accepted));
        }

        [HttpGet("donate")]
        public async Task<JsonResult> GetAcceptedDonation()
        {
            var accepted = await LogisticManager.FetchAcceptedDonation();
            return new JsonResult(Ok(accepted));
        }

        [HttpGet("update/request/{requestId}")]
        public async Task<JsonResult> UpdateRequestDelivery(int requestId)
        {
            var isSuccess = await LogisticManager.UpdateRequestStatus(requestId);
            return new JsonResult(isSuccess ? Ok() : NotFound());
        }

        [HttpGet("update/donate/{donationId}")]
        public async Task<JsonResult> UpdateDonationDelivery(int donationId)
        {
            var isSuccess = await LogisticManager.UpdateDonationStatus(donationId);
            return new JsonResult(isSuccess ? Ok() : NotFound());
        }
    }

}
