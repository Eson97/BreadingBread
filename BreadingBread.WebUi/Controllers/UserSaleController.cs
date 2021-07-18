using BreadingBread.Application.UseCases.UserPath.Commands.AssignPath;
using BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath;
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

        [HttpPost]
        public async Task<ActionResult<DeallocatePathResponse>> Deallocate([FromBody] DeallocatePathCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
