using FluentValidation;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale
{
    public class GetExcelByUserSaleValidator : AbstractValidator<GetExcelByUserSaleQuery>
    {
        public GetExcelByUserSaleValidator()
        {
            RuleFor(u => u.IdUserSale).GreaterThan(0);
            RuleFor(s => s.Sales).NotEmpty();
            RuleFor(s => s.UserSale).NotEmpty();
        }
    }
}
