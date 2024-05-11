using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class LogisticManager
    {
        public static async Task<List<Dictionary<string, object>>> FetchAcceptedRequest()
        {
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

        public static async Task<List<Dictionary<string, object>>> FetchAcceptedDonation()
        {
            string query = @"
                SELECT Donations.DonationId, DonorId, (CONCAT(UserFirstName, ' ', UserLastName)) AS DonorName, DonationName, DonationQuantity, DonationExpiry, DonationDate, DonationOriginalQuantity, DonationStatus
                FROM Donations
                JOIN UserInformations ON Donations.DonorId = UserInformations.UserId
                WHERE DonationQuantity = 0 AND DonationStatus = 'Pending'
                ORDER BY DonationId DESC";
            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<bool> UpdateRequestStatus(int requestId)
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

        public static async Task<bool> UpdateDonationStatus(int donationId)
        {
            string query = @"
                        UPDATE Donations
                        SET DonationStatus = 'Delivery'
                        WHERE DonationId = @DonationId
                    ";

            var parameters = new Dictionary<string, object>()
                    {
                        { "@DonationId", donationId },
                    };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);
            return res == 1;
        }
    }
}