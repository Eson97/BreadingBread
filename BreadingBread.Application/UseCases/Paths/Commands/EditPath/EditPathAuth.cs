using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Commands.EditPath
{
    public class EditPathAuth : IAdminRequest<EditPathCommand, EditPathResponse>
    {
        public EditPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {

        }
        
        public Task Validate(EditPathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
