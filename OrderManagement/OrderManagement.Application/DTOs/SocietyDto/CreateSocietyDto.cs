namespace OrderManagement.Application.DTOs.SocietyDto
{
    public class CreateSocietyDto
    {
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? PinCode { get; set; }
    }
}
