using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.AssignPath
{
    public class AssignPathHandler : IRequestHandler<AssignPathCommand, AssignPathResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime dateTime;
        private readonly IUserAccessor currentUser;

        public AssignPathHandler(IBreadingBreadDbContext db, IDateTime dateTime, IUserAccessor currentUser)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.currentUser = currentUser;
        }

        public async Task<AssignPathResponse> Handle(AssignPathCommand request, CancellationToken cancellationToken)
        {
            var path = await db.Path.FindAsync(request.IdPath);
            if (path == null)
                throw new NotFoundException("No se encuentra la ruta", request.IdPath);

            var assigned = await
                db.UserSale
                .Where(el => el.IdPath == request.IdPath
                || el.IdUser == request.IdUser
                //Si la ruta fue visitada el mismo dia
                && el.Visited.Date == dateTime.Now.Date)
                .FirstOrDefaultAsync();

            if (currentUser.UserId == assigned?.IdUser)
                return new AssignPathResponse { Id = assigned.Id };

            if (assigned != null)
                throw new BadRequestException("La ruta ya esta asignada");

            var toAssign = new UserSale
            {
                IdPath = request.IdPath,
                IdUser = request.IdUser,
                Visited = dateTime.Now
            };

            path.Selected = true;
            await db.UserSale.AddAsync(toAssign, cancellationToken);

            await db.SaveChangesAsync(cancellationToken);

            return new AssignPathResponse { Id = toAssign.Id };
        }
    }
}
