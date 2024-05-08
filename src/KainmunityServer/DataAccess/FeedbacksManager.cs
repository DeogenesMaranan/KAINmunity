using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class FeedbacksManager
    {
        public static async Task<bool> AddFeedback(FeedbackItem feedbackItem)
        {
            string query = "INSERT INTO Feedbacks (RespondentId, FeedbackContent)" +
                "VALUES (@RespondentId, @Content)";
            var parameters = new Dictionary<string, object>()
            {
                { "@RespondentId", feedbackItem.RespondentId },
                { "@Content", feedbackItem.Content }
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<List<Dictionary<string, object>>> FetchFeedbacks()
        {
            string query = "SELECT * FROM Feedbacks ORDER BY FeedbackId DESC";
            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<Dictionary<string, object>> GetFirstName(int userId)
        {
            string query = "SELECT UserFirstName FROM UserInformations NATURAL JOIN Feedbacks WHERE RespondentId = @UserId";
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