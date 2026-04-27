namespace OrderManagement.Infrastructure.Configuration
{
    public class EmailSettings
    {
        public string From { get; set; } = default!;
        public string SmtpHost { get; set; } = default!;
        public int Port { get; set; }
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
