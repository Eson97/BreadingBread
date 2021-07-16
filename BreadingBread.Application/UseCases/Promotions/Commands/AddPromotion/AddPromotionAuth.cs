using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Commands.AddPromotion
{
    public class AddPromotionAuth : IAdminRequest<AddPromotionCommand, AddPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public AddPromotionAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(AddPromotionCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
