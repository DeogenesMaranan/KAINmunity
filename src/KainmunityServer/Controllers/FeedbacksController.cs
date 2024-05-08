using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KainmunityServer.DataAccess;
using KainmunityServer.Models;

namespace KainmunityServer.Controllers
{
    [Route("api/feedback")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        [HttpPost("submit")]
        public async Task<JsonResult> SubmitFeedback(FeedbackItem feedbackItem)
        {
            var isSuccess = await FeedbacksManager.AddFeedback(feedbackItem);
            return new JsonResult(isSuccess ? Ok() : Unauthorized());
        }

        [HttpGet("all")]
        public async Task<JsonResult> GetAllFeedbacks()
        {
            var feedbacks = await FeedbacksManager.FetchFeedbacks();
            return new JsonResult(Ok(feedbacks));
        }
    }

}
