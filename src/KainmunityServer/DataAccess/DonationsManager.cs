using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class DonationsManager
    {
        public static async Task<bool> AddDonation(DonationItem donationItem)
        {
            string query = "INSERT INTO Donations (DonorId, DonationName, DonationQuantity, DonationExpiry)" +
                "Values (@DonorId, @Name, @Quantity, @Expiry);";
            var parameters = new Dictionary<string, object>()
            {
                { "@DonorId", donationItem.DonorId },
                { "@Name", donationItem.Name },
                { "@Quantity", donationItem.Quantity },
                { "@Expiry", donationItem.Expiry }
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<bool> MakeRequest(DonationRequest donationRequest)
        {
            string query = "INSERT INTO Requests (RequesterId, DonationId, RequestQuantity, RequestStatus)" +
                "VALUES (@RequesterId, @DonationId, @Quantity, @Status)";
            var parameters = new Dictionary<string, object>()
            {
                { "@RequesterId", donationRequest.RequesterId },
                { "@DonationId", donationRequest.DonationId },
                { "@Quantity", donationRequest.Quantity },
                { "@Status", donationRequest.Status }
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<bool> UpdateRequest(DonationRequest donationRequest)
        {
            string query = "UPDATE Requests SET RequestStatus = @RequestStatus WHERE RequestId = @RequestId";
            var parameters = new Dictionary<string, object>()
            {
                { "@RequestStatus", donationRequest.Status },
                { "@RequestId", donationRequest.DonationId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            if (res != 1)
            {
                return false;
            }

            if (donationRequest.Status == "Accepted")
            {
                query = "UPDATE Donations SET DonationQuantity = DonationQuantity - @RequestQuantity WHERE DonationId = @DonationId";
                parameters = new Dictionary<string, object>()
                {
                    { "@RequestQuantity", donationRequest.Quantity },
                    { "@DonationId", donationRequest.DonationId },
                };

                res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

                if (res != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static async Task<List<Dictionary<string, object>>> GetAvailable()
        {
            string query = "SELECT * FROM Donations WHERE DonationQuantity > 0 AND DonationExpiry > @CurrentDate ORDER BY DonationExpiry";
            var parameters = new Dictionary<string, object>()
            {
                { "@CurrentDate", DateTime.Now.ToString("yyyy-MM-dd") },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res;
        }
    }
}
