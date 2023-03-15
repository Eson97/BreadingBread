using BreadingBread.Application.UseCases.Inventory.Queries.GetProductList;
using BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale;
using BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale;
using BreadingBread.Application.UseCases.ReportSales.Queries.GetSalesReportList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [AllowAnonymous]
    public class ReportSalesController : BaseWebController
    {
        public async Task<IActionResult> Index()
        {
            var salesList = await Mediator.Send(new GetSalesReportListQuery());
            return View(salesList);
        }

        public async Task<IActionResult> DownloadReportSale(int idUserSale)
        {
            var file = await Mediator.Send(new DownloadExcelByUserSaleQuery(idUserSale));
            return File(file.File, "application/octet-stream", file.FileName);
        }

    }
}
