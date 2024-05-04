using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class AccountManager
    {
        public static async Task<bool> VerifyLogin(LoginDetails loginDetails)
        {
            string query = "SELECT * FROM UserCredentials WHERE UserContactNumber = @ContactNumber and UserPassword = @Password";
            var parameters = new Dictionary<string, object>()
            {
                { "@ContactNumber", loginDetails.ContactNumber },
                { "@Password", loginDetails.Password }
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res.Count > 0;
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
                { "@FirstName", userDetails.FirstName},
                { "@LastName", userDetails.LastName},
                { "@EmailAddress", userDetails.EmailAddress},
                { "@ContactNumber", userDetails.ContactNumber},
                { "@HomeAddress", userDetails.HomeAddress},
                { "@YearlyIncome", userDetails.YearlyIncome},
                { "@HouseholdSize", userDetails.HouseholdSize},
            };

            res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<bool> EditAccount(UserDetails userDetails)
        {
            // TK: return true if account editing is successful, else false
            throw new NotImplementedException();
        }
    }
}
