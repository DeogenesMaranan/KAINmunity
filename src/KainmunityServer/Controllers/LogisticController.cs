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
        [HttpPost("add/request")]
        public async Task<JsonResult> AddRequest(LogisticItem logisticsDetails)
        {
            var isSuccess = await LogisticManager.AddDeliveryRequest(logisticsDetails);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpPost("add/donate")]
        public async Task<JsonResult> AddDonation(LogisticItem logisticsDetails)
        {
            var isSuccess = await LogisticManager.AddDeliveryDonation(logisticsDetails);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

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

        [HttpGet("delivery/request/{courierId}")]
        public async Task<JsonResult> GetDeliveryRequest(int courierId)
        {
            var accepted = await LogisticManager.FetchRequestDelivery(courierId);
            return new JsonResult(Ok(accepted));
        }

        [HttpGet("delivery/donate/{courierId}")]
        public async Task<JsonResult> GetDeliveryDonation(int courierId)
        {
            var accepted = await LogisticManager.FetchDonationDelivery(courierId);
            return new JsonResult(Ok(accepted));
        }
    }
}