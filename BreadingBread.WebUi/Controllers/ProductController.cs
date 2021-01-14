using BreadingBread.Application.UseCases.Products.Commands.AddProduct;
using BreadingBread.Application.UseCases.Products.Commands.DeleteProduct;
using BreadingBread.Application.UseCases.Products.Commands.EditProduct;
using BreadingBread.Application.UseCases.Products.Queries.GetListProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AddProductResponse>> Add([FromBody] AddProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<EditProductResponse>> Edit([FromBody] EditProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeleteProductResponse>> Delete([FromBody] DeleteProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListProductsResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetListProductsQuery()));

        }
    }
}
