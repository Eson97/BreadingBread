using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetSalesReportList
{
    internal class GetSalesReportListValidator : AbstractValidator<GetSalesReportListQuery>
    {
        public GetSalesReportListValidator()
        {
        }
    }
}
