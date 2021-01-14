using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathAuth : IAdminRequest<GetListStoresByPathQuery, GetListStoresByPathResponse>
    {
        public GetListStoresByPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(GetListStoresByPathQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
