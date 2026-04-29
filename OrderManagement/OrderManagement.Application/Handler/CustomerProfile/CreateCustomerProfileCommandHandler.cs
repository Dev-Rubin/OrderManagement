using MediatR;
using OrderManagement.Application.Command.CustomerProfile;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.CustomerProfile
{
    public class CreateCustomerProfileCommandHandler(ICustomerProfileService s) : IRequestHandler<CreateCustomerProfileCommand, Result>
    { 
        public Task<Result> Handle(CreateCustomerProfileCommand r, CancellationToken _) => s.CreateAsync(r); 
    }
}
