using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Products.Commands.AddProduct
{
    public class AddProductAuth : IAdminRequest<AddProductCommand, AddProductResponse>
    {
        public AddProductAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(AddProductCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
