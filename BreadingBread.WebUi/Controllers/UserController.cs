using BreadingBread.Application.UseCases.Usuarios.Commands.AproveUsuario;
using BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUsuariosListResponse>> GetList()
        {
            return Ok(await Mediator.Send(new GetUsuariosListQuery()));

        }

        [HttpPost]
        public async Task<ActionResult<AproveUsuarioResponse>> Aprove([FromBody] AproveUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<DeleteUsuarioResponse>> Delete([FromBody] DeleteUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
