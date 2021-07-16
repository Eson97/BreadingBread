using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Commands.EditPromotion
{
    public class EditPromotionAuth : IAdminRequest<EditPromotionCommand, EditPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public EditPromotionAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(EditPromotionCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
