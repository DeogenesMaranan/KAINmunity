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
    internal class DonationManager
    {
        public static async Task<bool> AddDonation(string donationItem, int donationQuantity, string donationExpiry)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "donations/contribute", new Dictionary<string, object>
            {
                { "donorId", APIConnector.UserId },
                { "name", donationItem },
                { "quantity", donationQuantity },
                { "expiry", donationExpiry }
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<List<DonationItem>> GetDonations()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "donations/available");
            var donations = new List<DonationItem>();

            int statusCode = Convert.ToInt32(res["statusCode"]);

            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

            foreach (var item in dictionary)
            {
                donations.Add(new DonationItem()
                {
                    DonationId = Convert.ToInt32(item["DonationId"]),
                    DonorId = Convert.ToInt32(item["DonorId"]),
                    Name = Convert.ToString(item["DonationName"]),
                    Quantity = Math.Max(Convert.ToInt32(item["DonationQuantity"]), 0),
                    ExpiryDate = Convert.ToString(item["DonationExpiry"]),
                    Status = Convert.ToString(item["DonationStatus"])
                });
            }

            return donations;
        }

        public static async Task<List<Dictionary<string, object>>> GetRequests()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "donations/request");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<bool> UploadRequests(List<DonationRequest> requests)
        {
            var parameters = new List<object>();

            foreach (var request in requests)
            {
                parameters.Add(new Dictionary<string, object>()
                {
                    { "donationId", request.DonationId },
                    { "quantity", request.Quantity },
                });
            }

            var res = await APIConnector.SendRequest(RequestMethod.POST, "donations/request", listBody: parameters);
            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> UpdateRequests(List<DonationRequest> requests)
        {
            var convertedRequests = new List<object>();

            foreach (var request in requests)
            {
                convertedRequests.Add(new Dictionary<string, object>()
                {
                    { "requestId", request.RequestId },
                    { "requesterId", request.RequesterId },
                    { "donationId", request.DonationId },
                    { "quantity", request.Quantity },
                    { "status", request.Status },
                });
            }
            var res = await APIConnector.SendRequest(RequestMethod.PUT, "donations/request", listBody: convertedRequests);
            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<List<Dictionary<string, object>>> GetLeaderboard()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "donations/leaderboard");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<Dictionary<string, object>> GetAssociatedRequests(int donationId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"donations/request/{donationId}");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            return res;
        }
    }
}
