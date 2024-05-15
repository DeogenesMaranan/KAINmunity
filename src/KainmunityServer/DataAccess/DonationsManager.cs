using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class DonationsManager
    {
        public static async Task<bool> AddDonation(DonationItem donationItem)
        {
            string query = @"
                INSERT INTO Donations (DonorId, DonationName, DonationQuantity, DonationExpiry, DonationDate, DonationOriginalQuantity)
                Values (@DonorId, @Name, @Quantity, @Expiry, CURRENT_DATE, @Quantity)
            ";

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

        public static async Task<bool> MakeRequest(DonationRequest[] donationRequests)
        {
            string query = "INSERT INTO Requests (RequesterId, DonationId, RequestQuantity, RequestStatus, RequestDate)" +
                "VALUES";
            var parameters = new Dictionary<string, object>();

            for (int i = 0; i < donationRequests.Length; i++)
            {
                query += $" (@RequesterId{i}, @DonationId{i}, @Quantity{i}, @Status{i}, CURRENT_DATE)";

                if (i < donationRequests.Length - 1)
                {
                    query += ",";
                }

                parameters.Add($"@RequesterId{i}", donationRequests[i].RequesterId);
                parameters.Add($"@DonationId{i}", donationRequests[i].DonationId);
                parameters.Add($"@Quantity{i}", donationRequests[i].Quantity);
                parameters.Add($"@Status{i}", donationRequests[i].Status);
            }

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == donationRequests.Length;
        }

        public static async Task<bool> UpdateRequests(DonationRequest[] donationRequests)
        {
            string requestQuery = "UPDATE Requests SET RequestStatus = CASE RequestId ";
            string donationQuery = "UPDATE Donations SET DonationQuantity = CASE DonationId ";

            var requestIds = new List<int?>();
            var donationIds = new List<int?>();

            var requestParameters = new Dictionary<string, object>();
            var donationParameters = new Dictionary<string, object>();

            for (int i = 0; i < donationRequests.Length; i++)
            {
                requestQuery += $"WHEN @RequestId{i} THEN @RequestStatus{i} ";
                requestIds.Add(donationRequests[i].RequestId);
                requestParameters.Add($"@RequestId{i}", donationRequests[i].RequestId);
                requestParameters.Add($"@RequestStatus{i}", donationRequests[i].Status);

                if (donationRequests[i].Status == "Accepted")
                {
                    donationQuery += $"WHEN @DonationId{i} THEN DonationQuantity - @RequestQuantity{i} ";
                    donationIds.Add(donationRequests[i].DonationId);
                    donationParameters.Add($"@DonationId{i}", donationRequests[i].DonationId);
                    donationParameters.Add($"@RequestQuantity{i}", donationRequests[i].Quantity);
                }
            }

            requestQuery += $"END WHERE RequestId IN ({string.Join(", ", requestIds)})";
            donationQuery += $"END WHERE DonationId IN ({string.Join(", ", donationIds)})";

            var res = await DatabaseConnector.ExecuteNonQuery(requestQuery, requestParameters);

            if (res != requestIds.Count)
            {
                return false;
            }

            if (donationIds.Count > 0)
            {
                res = await DatabaseConnector.ExecuteNonQuery(donationQuery, donationParameters);
                if (res != donationIds.Count)
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

        public static async Task<List<Dictionary<string, object>>> GetRequests()
        {
            string query = @"
                SELECT RequestId, RequesterId, (CONCAT(UserFirstName, ' ', UserLastName)) AS RequesterName, Donations.DonationId, DonationName, RequestQuantity, RequestStatus 
                FROM Requests
                JOIN UserInformations ON Requests.RequesterId = UserInformations.UserId
                JOIN Donations ON Requests.DonationId = Donations.DonationId
                ORDER BY FIELD(RequestStatus, 'Pending', 'Accepted', 'Declined')";

            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<List<Dictionary<string, object>>> GetPendingDonations()
        {
            string query = @"
                SELECT DonationId, DonationDate, DonorId, (CONCAT(UserFirstName, ' ', UserLastName)) AS DonorName, DonationName, DonationQuantity, DonationExpiry FROM Donations
                JOIN UserInformations ON DonorId = UserId
                WHERE DonationStatus = 'Pending'
            ";

            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<Dictionary<string, object>> GetDonationDetails(int donationId)
        {
            string query = @"
                SELECT DonationId, DonationDate, DonorId, (CONCAT(UserFirstName, ' ', UserLastName)) AS DonorName, DonationName, DonationQuantity, DonationExpiry FROM Donations
                JOIN UserInformations ON DonorId = UserId
                WHERE DonationId = @DonationId
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DonationId", donationId },
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);

            return res.Count > 0 ? res[0] : null;
        }


        public static async Task<List<Dictionary<string, object>>> GetAssociatedRequests(int donationId)
        {
            string query = @"
                SELECT RequestId, RequestDate, (CONCAT(UserFirstName, ' ', UserLastName)) AS RequesterName, RequestQuantity, RequestStatus FROM Requests
                JOIN UserInformations ON RequesterId = UserId
                WHERE DonationId = @DonationId
                ORDER BY RequestDate;
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@DonationId", donationId }
            };

            var res = await DatabaseConnector.ExecuteQuery(query, parameters);
            return res;
        }

        public static async Task<List<Dictionary<string, object>>> FetchLeaderboard()
        {
            string query = "SELECT * FROM DonorLeaderboard";

            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }
    }
}
