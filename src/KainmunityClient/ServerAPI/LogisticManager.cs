using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KainmunityClient.Models;

namespace KainmunityClient.ServerAPI
{
    internal class LogisticManager
    {
        public static async Task<List<Dictionary<string, object>>> FetchAcceptedRequest()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "logistics/request");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<List<Dictionary<string, object>>> FetchAcceptedDonation()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "logistics/donate");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<bool> UpdateRequestStatus(int requestId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/update/request/{requestId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }
        public static async Task<bool> UpdateDonationStatus(int donationId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/update/donate/{donationId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> FinishRequestStatus(int requestId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/finish/request/{requestId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }
        public static async Task<bool> FinishDonationStatus(int donationId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/finish/donate/{donationId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> AddDeliveryRequest(int requestId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "logistics/add/request", new Dictionary<string, object>
            {
                { "courierId", APIConnector.UserId },
                { "requestId", requestId }
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> AddDeliveryDonation(int donationId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "logistics/add/donate", new Dictionary<string, object>
            {
                { "courierId", APIConnector.UserId },
                { "donationId", donationId }
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        // Show Delivery
        public static async Task<List<Dictionary<string, object>>> FetchRequestDelivery(int courierId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/delivery/request/{courierId}");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<List<Dictionary<string, object>>> FetchDonationDelivery(int courierId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/delivery/donate/{courierId}");

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
