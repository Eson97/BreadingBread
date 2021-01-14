using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.AddStore
{
    public class AddStoreAuth : IAdminRequest<AddStoreCommand, AddStoreResponse>
    {
        public AddStoreAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {

        }
        
        public Task Validate(AddStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
