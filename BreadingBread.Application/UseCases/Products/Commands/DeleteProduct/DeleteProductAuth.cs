using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Products.Commands.DeleteProduct
{
    public class DeleteProductAuth : IAdminRequest<DeleteProductCommand, DeleteProductResponse>
    {
        public DeleteProductAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(DeleteProductCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
