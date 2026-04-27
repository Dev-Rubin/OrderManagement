namespace OrderManagement.Infrastructure.Configuration
{
    public class OtpSettings
    {
        public int ExpiryMinutes { get; set; }
        public int Length { get; set; }
        public string Provider { get; set; } = default!;
        public SmsSettings Sms { get; set; } = new();
        public EmailSettings Email { get; set; } = new();
    }

}
