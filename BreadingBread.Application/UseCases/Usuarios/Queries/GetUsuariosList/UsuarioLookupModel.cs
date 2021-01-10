using BreadingBread.Domain.Enums;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class UsuarioLookupModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public UserType UserType { get; set; }
        public bool Aproved { get; set; }
    }
}