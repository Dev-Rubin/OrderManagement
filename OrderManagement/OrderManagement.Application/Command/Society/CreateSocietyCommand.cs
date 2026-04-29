using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Society
{
    public class CreateSocietyCommand : IRequest<Result>
    {
        public string Name { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? PinCode { get; set; }
    }
}
