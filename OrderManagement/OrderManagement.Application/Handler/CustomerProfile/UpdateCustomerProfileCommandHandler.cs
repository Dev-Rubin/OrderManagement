using MediatR;
using OrderManagement.Application.Command.CustomerProfile;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;

namespace OrderManagement.Application.Handler.CustomerProfile
{
    public class UpdateCustomerProfileCommandHandler(ICustomerProfileService s) : IRequestHandler<UpdateCustomerProfileCommand, Result>
    { 
        public Task<Result> Handle(UpdateCustomerProfileCommand r, CancellationToken _) => s.UpdateAsync(r);
    }
}
