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

            return res.Count > 0;
        } 
    }
}
