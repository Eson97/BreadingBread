using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Commands.SetInventoryToPath
{
    public class SetInventoryToPathAuth : IOtherRequest<SetInventoryToPathCommand, SetInventoryToPathResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public SetInventoryToPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(SetInventoryToPathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
