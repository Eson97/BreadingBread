using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionAuth : IAdminRequest<DeletePromotionCommand, DeletePromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public DeletePromotionAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(DeletePromotionCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
