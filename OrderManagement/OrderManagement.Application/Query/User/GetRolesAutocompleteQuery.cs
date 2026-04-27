using MediatR;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Query.User
{
    public record GetRolesAutocompleteQuery(string? Term) : IRequest<List<AutoCompleteItem>>;

}
