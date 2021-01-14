using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Products.Queries.GetListProducts
{
    public class GetListProductsAuth : IAdminRequest<GetListProductsQuery, GetListProductsResponse>
    {

        public GetListProductsAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(GetListProductsQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
