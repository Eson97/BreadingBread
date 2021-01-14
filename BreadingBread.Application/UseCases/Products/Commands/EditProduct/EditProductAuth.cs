using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Products.Commands.EditProduct
{
    public class EditProductAuth : IAdminRequest<EditProductCommand, EditProductResponse>
    {
        
        public EditProductAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(EditProductCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
