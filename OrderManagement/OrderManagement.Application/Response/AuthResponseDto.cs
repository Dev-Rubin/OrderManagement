namespace OrderManagement.Application.Response
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; } // seconds
        public string TokenType { get; set; } = "Bearer";
        public UserDto User { get; set; }
    }
}
