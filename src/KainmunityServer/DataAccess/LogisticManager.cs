using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class LogisticManager
    {
        public static async Task<List<Dictionary<string, object>>> FetchAccepted()
        {
            // string query = "SELECT * FROM Requests WHERE RequestStatus = 'Accepted' ORDER BY RequestId DESC";
            string query = @"
                SELECT RequestId, RequesterId, (CONCAT(UserFirstName, ' ', UserLastName)) AS RequesterName, Donations.DonationId, DonationName, RequestQuantity, RequestStatus 
                FROM Requests
                JOIN UserInformations ON Requests.RequesterId = UserInformations.UserId
                JOIN Donations ON Requests.DonationId = Donations.DonationId
                WHERE RequestStatus = 'Accepted'
                ORDER BY RequestId DESC";
            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<bool> UpdateDeliveryStatus(int requestId)
        {
            string query = @"
                        UPDATE Requests
                        SET RequestStatus = 'Delivery'
                        WHERE RequestId = @RequestId
                    ";

            var parameters = new Dictionary<string, object>()
                    {
                        { "@RequestId", requestId },
                    };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);
            return res == 1;
        }
    }
}