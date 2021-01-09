using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListResponse
    {
        public IList<UsuarioLookupModel> Usuarios { get; set; }
    }
}