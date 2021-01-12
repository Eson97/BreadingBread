using BreadingBread.Application.UseCases.Paths.Commands.AddPath;
using BreadingBread.Application.UseCases.Paths.Queries.GetListPath;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [ApiController]
    public class PathController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddPathResponse>> Add([FromBody] AddPathCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListPathResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetListPathQuery()));

        }
    }
}