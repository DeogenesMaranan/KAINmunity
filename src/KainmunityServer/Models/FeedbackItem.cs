namespace KainmunityServer.Models
{
    public class FeedbackItem
    {
        public int? FeedbackId { get; set; }
        public int RespondentId { get; set; }
        public string Content {  get; set; }
    }
}