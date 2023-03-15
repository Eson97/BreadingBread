using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale
{
    public class DownloadExcelByUserSaleValidator : AbstractValidator<DownloadExcelByUserSaleQuery>
    {
        public DownloadExcelByUserSaleValidator()
        {
            RuleFor(d => d.IdUserSale).GreaterThan(0);
        }
    }
}
