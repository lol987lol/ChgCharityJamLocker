namespace LockerOpener.Configuration
{
    public class LockerOptions
    {
        public string BaseUrl { get; set; }
        public string SiteId { get; set; }
        public string GeneralPin { get; set; } = "1234";

        public LockerAuthentication Authentication { get; set; }
    }

    public class LockerAuthentication
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Platform { get; set; } = "web";
    }
}
