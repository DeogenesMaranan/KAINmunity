using KainmunityServer.Models;

namespace KainmunityServer.DataAccess
{
    public class FeedbacksManager
    {
        public static async Task<bool> AddFeedback(FeedbackItem feedbackItem)
        {
            string query = "INSERT INTO Feedbacks (FeedbackContent, FeedbackStatus)" +
                "VALUES (@Content, 'Pending')";
            var parameters = new Dictionary<string, object>()
            {
                { "@Content", feedbackItem.Content }
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);

            return res == 1;
        }

        public static async Task<List<Dictionary<string, object>>> FetchFeedbacks()
        {
            string query = "SELECT * FROM Feedbacks WHERE FeedbackStatus = 'Pending' ORDER BY FeedbackId DESC";
            var res = await DatabaseConnector.ExecuteQuery(query);
            return res;
        }

        public static async Task<bool> ResolveFeedback(int feedbackId)
        {
            string query = @"
                UPDATE Feedbacks
                SET FeedbackStatus = 'Resolved'
                WHERE FeedbackId = @FeedbackId
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@FeedbackId", feedbackId },
            };

            var res = await DatabaseConnector.ExecuteNonQuery(query, parameters);
            return res == 1;
        }
    }

}