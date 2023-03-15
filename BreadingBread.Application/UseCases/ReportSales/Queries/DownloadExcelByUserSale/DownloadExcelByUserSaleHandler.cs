using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale;
using BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale
{
    public class DownloadExcelByUserSaleHandler : IRequestHandler<DownloadExcelByUserSaleQuery, DownloadExcelByUserSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IExcelService excelService;

        public DownloadExcelByUserSaleHandler(IBreadingBreadDbContext db, IExcelService excelService)
        {
            this.db = db;
            this.excelService = excelService;
        }

        public async Task<DownloadExcelByUserSaleResponse> Handle(DownloadExcelByUserSaleQuery request, CancellationToken cancellationToken)
        {
            var currentPath = await db.UserSale.Include(u => u.User).FirstOrDefaultAsync(us => us.Id == request.IdUserSale) ?? throw new NotFoundException(nameof(UserSale), request.IdUserSale);
            var path = await db.Path.FindAsync(currentPath.IdPath) ?? throw new NotFoundException("No se encuentra la ruta", currentPath.IdPath);
            
            var sales = await db.Sale
            .Include(p => p.Products)
            .ThenInclude(p => p.Product)
            .Where(s => s.IdUserSale == currentPath.Id).ToListAsync();

            var query = new GetExcelByUserSaleQuery(request.IdUserSale, currentPath, currentPath?.Sales?.ToList());
            var handler = new GetExcelByUserSaleHandler(excelService);
            var response = await handler.Handle(query, cancellationToken);

            if (response?.File == null)
            { throw new NotFoundException("No se pudo generar el excel", request.IdUserSale); }

            return new DownloadExcelByUserSaleResponse(response.FileName, response.File);
        }
    }
}
