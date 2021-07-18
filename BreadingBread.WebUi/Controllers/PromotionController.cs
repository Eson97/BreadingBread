using BreadingBread.Application.UseCases.Promotions.Commands.AddPromotion;
using BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion;
using BreadingBread.Application.UseCases.Promotions.Commands.EditPromotion;
using BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotion;
using BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotionByProduct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class PromotionController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddPromotionResponse>> Add([FromBody] AddPromotionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<EditPromotionResponse>> Edit([FromBody] EditPromotionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeletePromotionResponse>> Delete([FromBody] DeletePromotionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListPromotionResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetListPromotionQuery()));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListPromotionByProductResponse>> GetListByProduct(int idProduct)
        {
            return Ok(await Mediator.Send(new GetListPromotionByProductQuery { IdProducto = idProduct }));
        }
    }
}
