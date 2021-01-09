using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailQuery : IRequest<GetUsuarioDetailResponse>
    {
        public int? IdUsuario { get; set; }
    }
}