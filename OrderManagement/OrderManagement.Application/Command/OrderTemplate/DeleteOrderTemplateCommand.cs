using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.OrderTemplate
{
    public class DeleteOrderTemplateCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public DeleteOrderTemplateCommand(int id) => Id = id;
    }
}
