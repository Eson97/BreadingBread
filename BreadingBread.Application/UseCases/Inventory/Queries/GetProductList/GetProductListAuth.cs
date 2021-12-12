using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetProductList
{
    public class GetProductListAuth : IOtherRequest<GetProductListQuery, GetProductListResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetProductListAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetProductListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
