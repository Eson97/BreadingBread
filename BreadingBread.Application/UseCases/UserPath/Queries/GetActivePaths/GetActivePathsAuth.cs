using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Queries.GetActivePaths
{
    public class GetActivePathsAuth : IAdminRequest<GetActivePathsQuery, GetActivePathsResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetActivePathsAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetActivePathsQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
