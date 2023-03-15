using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetSalesReportList
{
    public class GetSalesReportListResponse
    {
        public GetSalesReportListResponse(IEnumerable<SaleReportDto> sales)
        {
            Sales = sales;
        }

        public IEnumerable<SaleReportDto> Sales { get; set; }
        public class SaleReportDto
        {
            public int IdUserSale { get; set; }
            public string Vendedor { get; set; }
            public string Ruta { get; set; }
            public string Tienda { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public decimal Importe { get; set; } = 0;
        }
    }
}
