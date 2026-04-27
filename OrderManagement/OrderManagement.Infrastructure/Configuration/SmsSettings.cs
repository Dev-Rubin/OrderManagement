namespace OrderManagement.Infrastructure.Configuration
{
    public class SmsSettings
    {
        public string ApiUrl { get; set; } = default!;
        public string ApiKey { get; set; } = default!;
        public string SenderId { get; set; } = default!;
    }
}
