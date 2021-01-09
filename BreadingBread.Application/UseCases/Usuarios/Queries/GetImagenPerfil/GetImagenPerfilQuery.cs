using BreadingBread.Domain.Enums;
using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilQuery : IRequest<GetImagenPerfilResponse>
    {
        public string NombreUsuario { get; set; }
        public MySize Size { get; set; }
    }
}