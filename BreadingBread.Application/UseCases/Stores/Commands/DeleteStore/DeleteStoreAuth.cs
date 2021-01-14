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
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public DeleteStoreAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(DeleteStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
