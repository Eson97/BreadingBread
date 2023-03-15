using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetSalesReportList
{
    public class GetSalesReportListHandler : IRequestHandler<GetSalesReportListQuery, GetSalesReportListResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetSalesReportListHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetSalesReportListResponse> Handle(GetSalesReportListQuery request, CancellationToken cancellationToken)
        {
            var sales = await db.UserSale.Select(s => new GetSalesReportListResponse.SaleReportDto
            {
                IdUserSale = s.Id,
                FechaInicio = s.Created,
                FechaFin = s.VisitedDate,
                Ruta = s.Path.Name,
                Vendedor = s.User.Name,
                Importe = s.Sales.Sum(s => s.Total)
            }).Take(1000).ToListAsync();

            return new GetSalesReportListResponse(sales);
        }
    }
}
