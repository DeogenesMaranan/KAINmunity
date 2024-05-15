using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class LogisticManager
    {
        // Post
        public static async Task<bool> AddDeliveryRequest(LogisticItem logisticsDetails)
        {
            string query = @"
                INSERT INTO Logistics (CourierId, RequestId)
                VALUES (@CourierId, @RequestId)";
            var parameters = new Dictionary<string, object>()
            {
                { "@CourierId", logisticsDetails.CourierId },
                { "@RequestId", logisticsDetails.RequestId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<bool> AddDeliveryDonation(LogisticItem logisticsDetails)
        {
            string query = @"
                INSERT INTO Logistics (CourierId, DonationId)
                VALUES (@CourierId, @DonationId)";
            var parameters = new Dictionary<string, object>()
            {
                { "@CourierId", logisticsDetails.CourierId },
                { "@DonationId", logisticsDetails.DonationId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        // Fetch
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
                WHERE DonationStatus = 'Accepted'
                ORDER BY DonationId DESC";
            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        // Fetch Delivery
        public static async Task<List<Dictionary<string, object>>> FetchRequestDelivery(int courierId)
        {
            string query = @"
                SELECT Requests.RequestId, Requests.RequesterId, 
                    CONCAT(UserInformations.UserFirstName, ' ', UserInformations.UserLastName) AS RequesterName, 
                    Donations.DonationId, Donations.DonationName, Donations.DonationQuantity,
                    Requests.RequestQuantity, Requests.RequestStatus
                FROM Logistics
                JOIN Requests ON Logistics.RequestId = Requests.RequestId
                JOIN UserInformations ON Requests.RequesterId = UserInformations.UserId
                JOIN Donations ON Requests.DonationId = Donations.DonationId
                WHERE CourierId = @CourierId
                ORDER BY Requests.RequestId DESC";

            var parameters = new Dictionary<string, object>()
                {
                    { "@CourierId", courierId },
                };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            return res;
        }

        public static async Task<List<Dictionary<string, object>>> FetchDonationDelivery(int courierId)
        {
            string query = @"
                SELECT 
                    CONCAT(UserInformations.UserFirstName, ' ', UserInformations.UserLastName) AS DonorName, 
                    Donations.DonationId, Donations.DonationName, Donations.DonationOriginalQuantity, Donations.DonationStatus, Donations.DonorId
                FROM Logistics
                JOIN Donations ON Logistics.DonationId = Donations.DonationId
                JOIN UserInformations ON Donations.DonorId = UserInformations.UserId
                WHERE CourierId = @CourierId
                ORDER BY Donations.DonationId DESC";

            var parameters = new Dictionary<string, object>()
            {
                { "@CourierId", courierId },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            return res;
        }

        // Update
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

        public static async Task<bool> FinishRequestStatus(int requestId)
    {
        string query = @"
                        UPDATE Requests
                        SET RequestStatus = 'Delivered'
                        WHERE RequestId = @RequestId
                    ";

        var parameters = new Dictionary<string, object>()
                    {
                        { "@RequestId", requestId },
                    };

        var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);
        return res == 1;
    }

    public static async Task<bool> FinishDonationStatus(int donationId)
    {
        string query = @"
                        UPDATE Donations
                        SET DonationStatus = 'Received'
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