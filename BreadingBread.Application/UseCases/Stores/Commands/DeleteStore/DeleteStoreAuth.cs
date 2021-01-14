using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.DeleteStore
{
    public class DeleteStoreAuth : IAdminRequest<DeleteStoreCommand, DeleteStoreResponse>
    {
        public DeleteStoreAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(DeleteStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
