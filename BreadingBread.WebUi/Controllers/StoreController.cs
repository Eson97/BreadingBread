using BreadingBread.Application.UseCases.Stores.Commands.SetCoor;
using BreadingBread.Application.UseCases.Stores.Queries.GetListStores;
using BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [ApiController]
    public class StoreController : BaseController
    {
        public StoreController()
        {
        }

        [HttpPost]
        public async Task<ActionResult<SetCoorResponse>> SetCoordinates([FromBody] SetCoorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListStoresByPathResponse>> GetListByPath(int idPath)
        {
            return Ok(await Mediator.Send(new GetListStoresByPathQuery { IdPath = idPath }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListStoresResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetListStoresQuery()));
        }
    }
}
