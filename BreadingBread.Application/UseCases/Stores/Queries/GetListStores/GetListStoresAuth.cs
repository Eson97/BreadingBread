using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresAuth : IAdminRequest<GetListStoresQuery, GetListStoresResponse>
    {

        public GetListStoresAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        
        }
        
        public Task Validate(GetListStoresQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
