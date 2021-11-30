using BreadingBread.Application.UseCases.Sale.Commands.AddSale;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class SaleController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddSaleResponse>> Add([FromBody] AddSaleCommand data)
        {
            return Ok(await Mediator.Send(data));
        }

    }
}
