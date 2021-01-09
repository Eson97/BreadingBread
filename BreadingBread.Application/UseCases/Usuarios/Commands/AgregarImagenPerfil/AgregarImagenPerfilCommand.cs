using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilCommand : IRequest<AgregarImagenPerfilResponse>
    {
        public string Imagen { get; set; }
    }
}