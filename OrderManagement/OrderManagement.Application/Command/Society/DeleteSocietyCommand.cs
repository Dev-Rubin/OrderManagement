using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Command.Society
{
    public class DeleteSocietyCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public DeleteSocietyCommand(int id) => Id = id;
    }
}
