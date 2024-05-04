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
    }
}
