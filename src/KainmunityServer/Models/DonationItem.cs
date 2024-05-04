namespace KainmunityServer.Models
{
    public class DonationItem
    {
        public int DonorId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Expiry { get; set; }
    }
}
