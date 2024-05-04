using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KainmunityClient.ServerAPI
{
    internal class AccountManager
    {
        public static async Task<bool> VerifyLogin(string contactNumber, string password)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "account/login", new Dictionary<string, object> {
                { "contactNumber", contactNumber },
                { "password", password },
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }

        public static async Task<bool> CreateAccount(string firstName, string lastName, string pass, string email, string contactNumber, string address, double income, int size)
        {
            var res = await APIConnector.SendRequest(RequestMethod.POST, "account/signup", new Dictionary<string, object>
            {
                {"firstName", firstName},
                {"lastName", lastName },
                {"emailAddress", email },
                {"contactNumber", contactNumber},
                {"homeAddress", address},
                {"yearlyIncome", income},
                {"householdSize", size},
                {"password", pass}
            });

            return Convert.ToInt64(res["statusCode"]) == 200;
        }
    }
}
