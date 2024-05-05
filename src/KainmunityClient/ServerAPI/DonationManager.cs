using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
