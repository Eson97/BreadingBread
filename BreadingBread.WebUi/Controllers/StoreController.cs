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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListStoresByPathResponse>> GetList(int idPath)
        {
            return Ok(await Mediator.Send(new GetListStoresByPathQuery { IdPath = idPath }));

        }
    }
}
