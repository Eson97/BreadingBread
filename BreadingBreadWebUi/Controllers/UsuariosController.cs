using BreadingBread.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil;
using BreadingBread.Application.UseCases.Usuarios.Commands.AproveUsuario;
using BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario;
using BreadingBread.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario;
using BreadingBread.Application.UseCases.Usuarios.Commands.ModificarEmail;
using BreadingBread.Application.UseCases.Usuarios.Commands.ModificarPassword;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetImagenPerfil;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioDetail;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList;
using BreadingBread.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.Controllers
{
    public class UsuariosController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUsuariosListResponse>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsuariosListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUsuarioDetailResponse>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetUsuarioDetailQuery { IdUsuario = id }));
        }

        [HttpPut("{nombreUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AproveUsuarioResponse>> AproveUser(string nombreUsuario)
        {
            return Ok(await Mediator.Send(new AproveUsuarioCommand { NombreUsuario = nombreUsuario }));
        }

        [HttpDelete("{nombreUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DeleteUsuarioResponse>> DeleteUser(string nombreUsuario)
        {
            return Ok(await Mediator.Send(new DeleteUsuarioCommand { NombreUsuario = nombreUsuario }));
        }

        [HttpPut]
        public async Task<ActionResult<ModificarDatosUsuarioResponse>> ModificarDatos([FromBody] ModificarDatosUsuarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<ModificarEmailResponse>> ModificarEmail([FromBody] ModificarEmailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<ModificarPasswordResponse>> ModificarPassword([FromBody] ModificarPasswordCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<ActionResult<AgregarImagenPerfilResponse>> ImagenPerfil(AgregarImagenPerfilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{nombreUsuario}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetImagenPerfil(string nombreUsuario, MySize size = MySize.Small)
        {
            var response = await Mediator.Send(new GetImagenPerfilQuery { NombreUsuario = nombreUsuario, Size = size });
            if (response == null) return NotFound();
            return File(response.Imagen, response.ContentType);
        }
    }
}