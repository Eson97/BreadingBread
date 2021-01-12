namespace BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioResponse : NotificationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}