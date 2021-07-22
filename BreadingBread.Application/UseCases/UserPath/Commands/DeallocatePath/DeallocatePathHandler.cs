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

        public DeallocatePathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeallocatePathResponse> Handle(DeallocatePathCommand request, CancellationToken cancellationToken)
        {
            var currentPath = await db.UserSale.FindAsync(request.Id);
            if (currentPath == null)
                throw new NotFoundException(nameof(UserSale), request.Id);

            var path = await db.Path.FindAsync(currentPath.IdPath);
            if (path == null)
                throw new NotFoundException("No se encuentra la ruta", currentPath.IdPath);

            //TODO probar si al eliminar se eliminan la venta y el detalle de la venta
            path.Selected = false;
            db.UserSale.Remove(currentPath);

            await db.SaveChangesAsync(cancellationToken);
            return new DeallocatePathResponse();
        }
    }
}
