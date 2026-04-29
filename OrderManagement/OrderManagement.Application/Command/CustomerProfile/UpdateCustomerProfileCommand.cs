using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.CustomerProfile
{
    public class UpdateCustomerProfileCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string? FlatOrVillaNumber { get; set; }
        public string? Block { get; set; }
        public string? WhatsAppId { get; set; }
        public bool IsActive { get; set; }
    }
}
