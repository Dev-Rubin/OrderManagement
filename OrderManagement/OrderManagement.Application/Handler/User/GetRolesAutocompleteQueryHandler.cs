using MediatR;
using OrderManagement.Application.Command.Auth;
using OrderManagement.Application.Query.User;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.User
{
    public class GetRolesAutocompleteQueryHandler : IRequestHandler<GetRolesAutocompleteQuery, List<AutoCompleteItem>>
    {
        private readonly IUserRepository _repo;

        public GetRolesAutocompleteQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AutoCompleteItem>> Handle(GetRolesAutocompleteQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetRolesAutocompleteAsync(request);
        }
    }
}
