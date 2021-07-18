using BreadingBread.Application.UseCases.Sale.Commands.AddSale;
using BreadingBread.Application.UseCases.SaleProduct.Commands.AddProductSale;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class SaleController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddSaleResponse>> AddSale([FromBody] AddSaleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<AddProductSaleResponse>> AddProduct([FromBody] AddProductSaleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
