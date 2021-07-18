using BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory;
using BreadingBread.Application.UseCases.Inventory.Commands.DeleteProductoFromInventory;
using BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class InventoryController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddProductToInventoryResponse>> Add([FromBody] AddProductToInventoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeleteProductoFromInventoryResponse>> Delete([FromBody] DeleteProductoFromInventoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListInventoryByProductResponse>> GetList(int idProduct, int idSaleUser)
        {
            return Ok(await Mediator.Send(new GetListInventoryByProductQuery
            {
                IdProduct = idProduct,
                IdSaleUser = idSaleUser
            }));
        }
    }
}
