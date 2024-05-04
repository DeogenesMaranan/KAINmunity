using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class AccountManager
    {
        public static async Task<bool> VerifyLogin(LoginDetails loginDetails)
        {
            string query = "SELECT * FROM UserTbl WHERE UserCPNumber = @ContactNumber and UserPass = @Password";
            var parameters = new Dictionary<string, object>()
            {
                { "@ContactNumber", loginDetails.ContactNumber },
                { "@Password", loginDetails.Password },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res.Count > 0;
        }

        public static async Task<bool> CreateAccount(UserDetails userDetails)
        {
            // TK: return true if account registration is successful, else false
            throw new NotImplementedException();
        }

        public static async Task<bool> EditAccount(UserDetails userDetails)
        {
            // TK: return true if account editing is successful, else false
            throw new NotImplementedException();
        }
    }
}
