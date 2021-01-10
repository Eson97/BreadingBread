using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using BreadingBread.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioResponse>
    {
        private readonly IMediator mediator;
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime dateTime;
        private readonly IRandomGenerator randomGenerator;

        public CreateUsuarioHandler(IBreadingBreadDbContext db, IMediator mediator, IDateTime dateTime, IRandomGenerator randomGenerator)
        {
            this.mediator = mediator;
            this.db = db;
            this.dateTime = dateTime;
            this.randomGenerator = randomGenerator;
        }

        public async Task<CreateUsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            string pass = PasswordStorage.CreateHash(request.Password);

            var user = new User
            {
                UserName = request.UserName,
                HashedPassword = pass,
                UserType = (UserType)request.UserType,
                Aproved = false,
                TokenConfirmacion = randomGenerator.Guid(),
                Name = request.Name,
                NormalizedUserName = request.UserName.ToUpper()
            };
            db.User.Add(user);

            await db.SaveChangesAsync(cancellationToken);

            string mensaje = "Usuario Creado, espere a que el Administrador Confirme su Cuenta";

            return new CreateUsuarioResponse
            {
                Id = user.Id,
                NombreUsuario = user.UserName,
                NotificationMessage = mensaje,
                Nombre = user.Name
            };
        }
    }
}