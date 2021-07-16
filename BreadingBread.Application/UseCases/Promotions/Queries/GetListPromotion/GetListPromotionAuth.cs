using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotion
{
    public class GetListPromotionAuth : IAdminRequest<GetListPromotionQuery, GetListPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetListPromotionAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetListPromotionQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
