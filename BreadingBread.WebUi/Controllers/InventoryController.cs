
using BreadingBread.Application.UseCases.Inventory.Commands.SetInventoryToPath;
using BreadingBread.Application.UseCases.Inventory.Queries.GetProductList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class InventoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<SetInventoryToPathResponse>> Set([FromBody] SetInventoryToPathCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetProductListResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetProductListQuery()));
        }
    }
}
