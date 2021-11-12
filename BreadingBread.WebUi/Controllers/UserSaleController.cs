using BreadingBread.Application.UseCases.UserPath.Commands.AssignPath;
using BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath;
using BreadingBread.Application.UseCases.UserPath.Queries.GetPathByUser;
using BreadingBread.Application.UseCases.UserPath.Queries.GetActivePaths;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class UserSaleController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AssignPathResponse>> Assign([FromBody] AssignPathCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<GetPathByUserResponse>> GetPathByUser()
        {
            return Ok(await Mediator.Send(new GetPathByUserQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<GetActivePathsResponse>> GetActivePaths()
        {
            return Ok(await Mediator.Send(new GetActivePathsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<DeallocatePathResponse>> Deallocate([FromBody] DeallocatePathCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
