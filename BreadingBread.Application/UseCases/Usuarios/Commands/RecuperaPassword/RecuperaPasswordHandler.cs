using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPassword
{
    public class RecuperaPasswordHandler : IRequestHandler<RecuperaPasswordCommand, RecuperaPasswordResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public RecuperaPasswordHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<RecuperaPasswordResponse> Handle(RecuperaPasswordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
                .User
                .SingleOrDefaultAsync(el => el.TokenConfirmacion == request.Token);

            if (usuario == null) throw new NotFoundException(nameof(User), new { });

            string pass = PasswordStorage.CreateHash(request.Password);

            usuario.HashedPassword = pass;
            usuario.TokenConfirmacion = null;

            await db.SaveChangesAsync(cancellationToken);

            return new RecuperaPasswordResponse();
        }
    }
}