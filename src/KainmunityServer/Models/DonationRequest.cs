namespace KainmunityServer.Models
{
    public class DonationRequest
    {
        public int? RequestId { get; set; }
        public int RequesterId { get; set; }
        public int DonationId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
