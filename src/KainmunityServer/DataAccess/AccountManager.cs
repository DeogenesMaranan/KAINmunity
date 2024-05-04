using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class AccountManager
    {
        public static async Task<int> VerifyLogin(LoginDetails loginDetails)
        {
            string query = "SELECT * FROM UserCredentials WHERE UserContactNumber = @ContactNumber and UserPassword = @Password";
            var parameters = new Dictionary<string, object>()
            {
                { "@ContactNumber", loginDetails.ContactNumber },
                { "@Password", loginDetails.Password }
            };
            
            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            
            if (res.Count == 0)
            {
                return -1;
            }

            return Convert.ToInt32(res[0]["UserId"]);
        }

        public static async Task<bool> CreateAccount(UserDetails userDetails)
        {
            string query = "INSERT INTO UserCredentials (UserContactNumber, UserPassword) VALUES (@ContactNumber, @Password)";
            var parameters = new Dictionary<string, object>()
            {
                { "@ContactNumber", userDetails.ContactNumber },
                { "@Password", userDetails.Password }
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            if (res != 1)
            {
                return false;
            }

            query = "INSERT INTO UserInformations (UserId, UserFirstName, UserLastName, UserEmailAddress, UserContactNumber, UserHomeAddress, UserYearlyIncome, UserHouseholdSize) " + 
                "VALUES ((SELECT MAX(UserId) FROM UserCredentials), @FirstName, @LastName, @EmailAddress, @ContactNumber, @HomeAddress, @YearlyIncome, @HouseholdSize)";
            
            parameters = new Dictionary<string, object>()
            {
                { "@FirstName", userDetails.FirstName },
                { "@LastName", userDetails.LastName },
                { "@EmailAddress", userDetails.EmailAddress },
                { "@ContactNumber", userDetails.ContactNumber },
                { "@HomeAddress", userDetails.HomeAddress },
                { "@YearlyIncome", userDetails.YearlyIncome },
                { "@HouseholdSize", userDetails.HouseholdSize },
            };

            res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<bool> EditAccount(int userId, UserDetails userDetails)
        {
            string query = "UPDATE UserCredentials SET UserPassword = @Password WHERE UserId = @UserId";
            var parameters = new Dictionary<string, object>()
            {
                { "@Password", userDetails.Password },
                { "@UserId", userId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            if (res != 1)
            {
                return false;
            }

            query = "UPDATE UserInformations SET UserEmailAddress = @EmailAddress, UserHomeAddress = @HomeAddress, UserYearlyIncome = @YearlyIncome, UserHouseholdSize = @HouseholdSize WHERE UserId = @UserId";

            parameters = new Dictionary<string, object>()
            {
                { "@EmailAddress", userDetails.EmailAddress },
                { "@HomeAddress", userDetails.HomeAddress },
                { "@YearlyIncome", userDetails.YearlyIncome },
                { "@HouseholdSize", userDetails.HouseholdSize },
                { "@UserId", userId },
            };

            res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<Dictionary<string, object>> GetAccountInfo(int userId)
        {
            string query = "SELECT * FROM UserInformations WHERE UserId = @UserId";
            var parameters = new Dictionary<string, object>()
            {
                { "@UserId", userId },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            if (res.Count == 0)
            {
                return null;
            }

            return res[0];
        }
    }
}
