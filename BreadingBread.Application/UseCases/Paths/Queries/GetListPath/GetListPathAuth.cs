using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Queries.GetListPath
{
    public class GetListPathAuth : IAuthenticatedRequest<GetListPathQuery, GetListPathResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetListPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(GetListPathQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
