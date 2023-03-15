using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale
{
    public class DownloadExcelByUserSaleQuery : IRequest<DownloadExcelByUserSaleResponse>
    {
        public DownloadExcelByUserSaleQuery(int idUserSale)
        {
            IdUserSale = idUserSale;
        }

        public int IdUserSale { get; set; }
    }
}
