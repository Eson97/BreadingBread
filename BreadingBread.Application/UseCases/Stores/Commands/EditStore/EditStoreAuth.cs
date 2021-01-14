using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreAuth : IAdminRequest<EditStoreCommand, EditStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public EditStoreAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(EditStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
