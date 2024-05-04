namespace KainmunityServer.Models
{
    public class UserDetails
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? ContactNumber { get; set; }
        public string? HomeAddress { get; set; }
        public decimal YearlyIncome {  get; set; }
        public int HouseholdSize { get; set; }
        public string? Password { get; set; }
    }
}
