using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class AccountManager
    {
        public static async Task<bool> VerifyLogin(LoginDetails loginDetails)
        {
            // TK: return true if login is successful, else false
            throw new NotImplementedException();
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
