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
    }
}
