using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale
{
    public class DownloadExcelByUserSaleAuth : IAuthenticatedRequest<DownloadExcelByUserSaleQuery, DownloadExcelByUserSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public DownloadExcelByUserSaleAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(DownloadExcelByUserSaleQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
