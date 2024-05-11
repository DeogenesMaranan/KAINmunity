using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KainmunityClient.ServerAPI
{
    internal class LogisticManager
    {
        public static async Task<List<Dictionary<string, object>>> FetchAccepted()
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, "logistics/all");

            long statusCode = Convert.ToInt64(res["statusCode"]);
            if (statusCode != 200)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(res["value"]);
            var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return dictionary;
        }

        public static async Task<bool> UpdateDeliveryStatus(int requestId)
        {
            var res = await APIConnector.SendRequest(RequestMethod.GET, $"logistics/update/{requestId}");
            return Convert.ToInt64(res["statusCode"]) == 200;
        }
    }
}
