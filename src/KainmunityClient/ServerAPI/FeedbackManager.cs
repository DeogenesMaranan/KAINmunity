using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KainmunityClient.Models;
using System.Windows.Forms;

namespace KainmunityClient.ServerAPI
{
    internal class FeedbackManager
    {
        public static async Task<bool> AddFeedback(string feedbackContent)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "feedback/submit", new Dictionary<string, object>
            {
                { "content", feedbackContent }
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> ResolveFeedback(int feedbackId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"feedback/resolve/{feedbackId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<List<Dictionary<string, object>>> FetchFeedbacks()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "feedback/all");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }
    }
}
