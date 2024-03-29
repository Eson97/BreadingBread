﻿using BreadingBread.Application.UseCases.PathStore.Commands.AssignStore;
using BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore;
using BreadingBread.Application.UseCases.Stores.Commands.AddStore;
using BreadingBread.Application.UseCases.Stores.Commands.DeleteStore;
using BreadingBread.Application.UseCases.Stores.Commands.EditStore;
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
        public async Task<ActionResult<AddStoreResponse>> Add([FromBody] AddStoreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<EditStoreResponse>> Edit([FromBody] EditStoreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeleteStoreResponse>> Delete([FromBody] DeleteStoreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<SetCoorResponse>> SetCoordinates([FromBody] SetCoorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<AssignStoreResponse>> Assign([FromBody] AssignStoreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeallocateStoreResponse>> Deallocate([FromBody] DeallocateStoreCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListStoresResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetListStoresQuery()));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetListStoresByPathResponse>> GetListByPath(int idPath)
        {
            return Ok(await Mediator.Send(new GetListStoresByPathQuery { IdPath = idPath }));
        }
    }
}
