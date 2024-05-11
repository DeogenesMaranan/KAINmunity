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
        [HttpGet("all")]
        public async Task<JsonResult> GetAllAccepted()
        {
            var accepted = await LogisticManager.FetchAccepted();
            return new JsonResult(Ok(accepted));
        }

        [HttpGet("update/{requestId}")]
        public async Task<JsonResult> UpdateDelivery(int requestId)
        {
            var isSuccess = await LogisticManager.UpdateDeliveryStatus(requestId);
            return new JsonResult(isSuccess ? Ok() : NotFound());
        }

        // [HttpGet("resolve/{feedbackId}")]
        // public async Task<JsonResult> ResolveFeedback(int feedbackId)
        // {
        //     var isSuccess = await FeedbacksManager.ResolveFeedback(feedbackId);
        //     return new JsonResult(isSuccess ? Ok() : NotFound());
        // }
    }

}
