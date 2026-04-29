using MediatR;
using OrderManagement.Application.Query.Catalog;
using OrderManagement.Application.Repository;
using OrderManagement.Persistence.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Application.Handler.Catalog
{
    public class GetAllCatalogsQueryHandler(ICatalogService s) : IRequestHandler<GetAllCatalogsQuery, Result>
    { 
        public Task<Result> Handle(GetAllCatalogsQuery r, CancellationToken _) => s.GetAllAsync(r.MerchantId, r.Date); 
    }
}
