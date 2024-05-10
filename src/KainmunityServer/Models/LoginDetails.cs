namespace KainmunityServer.Models
{
    public class LoginDetails
    {
        public string? ContactNumber { get; set; }
        public string? Password { get; set; }
        public string? AccountType { get; set; }
        public bool? IsAuthorized { get; set; }
        public int? UserId { get; set; }
    }
}
