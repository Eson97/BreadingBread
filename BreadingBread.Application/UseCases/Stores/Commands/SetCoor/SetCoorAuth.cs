using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.SetCoor
{
    public class SetCoorAuth : IAdminRequest<SetCoorCommand, SetCoorResponse>
    {
        public SetCoorAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(SetCoorCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
