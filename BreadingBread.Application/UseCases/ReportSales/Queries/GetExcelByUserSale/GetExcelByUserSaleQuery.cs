using BreadingBread.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale
{
    public class GetExcelByUserSaleQuery : IRequest<GetExcelByUserSaleResponse>
    {
        public GetExcelByUserSaleQuery(int idUserSale, UserSale userSale, List<Domain.Entities.Sale> sales)
        {
            IdUserSale = idUserSale;
            UserSale = userSale;
            Sales = sales;
        }

        public int IdUserSale { get; set; }
        public UserSale UserSale { get; set; }
        public List<Domain.Entities.Sale> Sales { get; set; }
    }
}
