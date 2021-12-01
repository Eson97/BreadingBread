using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathHandler : IRequestHandler<DeallocatePathCommand, DeallocatePathResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IMediator mediator;

        public DeallocatePathHandler(IBreadingBreadDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<DeallocatePathResponse> Handle(DeallocatePathCommand request, CancellationToken cancellationToken)
        {
            var currentPath = await db.UserSale.FindAsync(request.Id);
            if (currentPath == null)
                throw new NotFoundException(nameof(UserSale), request.Id);

            var path = await db.Path.FindAsync(currentPath.IdPath);
            if (path == null)
                throw new NotFoundException("No se encuentra la ruta", currentPath.IdPath);

            //path.Selected = false;
            //currentPath.Visited = true;
            await db.SaveChangesAsync(cancellationToken);

            _ = mediator.Publish(new DeallocatePathNotificate
            {
                IdUserSale = currentPath.Id
            }, cancellationToken);

            return new DeallocatePathResponse();
        }
    }
}
