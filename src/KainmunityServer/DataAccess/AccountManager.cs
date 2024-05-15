using KainmunityServer.Models;
using BCrypt.Net;

namespace KainmunityServer.DataAccess
{
    public class AccountManager
    {
        public static async Task<LoginDetails> VerifyLogin(LoginDetails loginDetails)
        {
            string query = "SELECT UserId, UserPassword, UserType FROM UserCredentials WHERE UserContactNumber = @ContactNumber";
            var parameters = new Dictionary<string, object>()
                {
                    { "@ContactNumber", loginDetails.ContactNumber }
                };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            if (res.Count == 0)
            {
                return new LoginDetails { IsAuthorized = false };
            }

            string hashedPasswordFromDb = Convert.ToString(res[0]["UserPassword"]);

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginDetails.Password, hashedPasswordFromDb);

            if (!passwordMatch)
            {
                return new LoginDetails { IsAuthorized = false };
            }

            return new LoginDetails()
            {
                IsAuthorized = true,
                UserId = Convert.ToInt32(res[0]["UserId"]),
                AccountType = Convert.ToString(res[0]["UserType"]),
            };
        }

        public static async Task<bool> CreateAccount(UserDetails userDetails)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDetails.Password, salt);
            string query = "INSERT INTO UserCredentials (UserContactNumber, UserPassword) VALUES (@ContactNumber, @Password)";
            var parameters = new Dictionary<string, object>()
            {
                { "@ContactNumber", userDetails.ContactNumber },
                { "@Password", hashedPassword }
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
            if (userDetails.isPasswordModified)
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDetails.Password, salt);
                string changePassword = "UPDATE UserCredentials SET UserPassword = @Password WHERE UserId = @UserId";
                var par = new Dictionary<string, object>()
                    {
                        { "@Password", hashedPassword },
                        { "@UserId", userId }
                    };

                var result = await DatabaseConnector.ExecuteNonQuery(changePassword, par);
                if (result != 1)
                {
                    return false;
                }
            }

            string query = "UPDATE UserInformations SET UserEmailAddress = @EmailAddress, UserHomeAddress = @HomeAddress, UserYearlyIncome = @YearlyIncome, UserHouseholdSize = @HouseholdSize WHERE UserId = @UserId";

            var parameters = new Dictionary<string, object>()
            {
                { "@EmailAddress", userDetails.EmailAddress },
                { "@HomeAddress", userDetails.HomeAddress },
                { "@YearlyIncome", userDetails.YearlyIncome },
                { "@HouseholdSize", userDetails.HouseholdSize },
                { "@UserId", userId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<Dictionary<string, object>> GetAccountInfo(int userId)
        {
            string query = @"
                SELECT * FROM UserInformations
                JOIN UserCredentials ON UserCredentials.UserId = UserInformations.UserId
                WHERE UserInformations.UserId = @UserId
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@UserId", userId },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            if (res.Count == 0)
            {
                Console.WriteLine("hehe");
                return null;
            }

            return res[0];
        }

        public static async Task<List<Dictionary<string, object>>> GetRequestHistory(int userId)
        {
            string query = @"
                SELECT Requests.RequestId, Requests.DonationId, RequestDate, DonationName, RequestQuantity, RequestStatus FROM Requests
                JOIN Donations ON Requests.DonationId = Donations.DonationId
                WHERE RequesterId = @RequesterId
                ORDER BY RequestDate DESC
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@RequesterId", userId }
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res;
        }

        public static async Task<List<Dictionary<string, object>>> GetDonationHistory(int userId)
        {
            string query = @"
                SELECT * FROM Donations
                WHERE DonorId = @DonorId
                ORDER BY DonationDate DESC, DonationId DESC
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DonorId", userId },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res;
        }
    }
}
