using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Commands.DeletePath
{
    public class DeletePathAuth : IAdminRequest<DeletePathCommand, DeletePathResponse>
    {
        public DeletePathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(DeletePathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
