using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Commands.AddPath
{
    public class AddPathAuth : IAdminRequest<AddPathCommand, AddPathResponse>
    {
        public AddPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }

        public Task Validate(AddPathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
