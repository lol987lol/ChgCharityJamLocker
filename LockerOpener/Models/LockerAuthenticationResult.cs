namespace LockerOpener.Models
{
    public class LockerAuthenticationResult : GeneralLockerResult
    {
        public AuthenticationResponse Result { get; set; }
    }

    public class AuthenticationResponse
    {
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public int SubscriptionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ForceChangePassword { get; set; }
        public string[] WaysOfIdentification { get; set; }
        public string Language { get; set; }
        public bool IsCustomerAd { get; set; }
        public bool IsBlocked { get; set; }
        public string Provider { get; set; }
    }
}

