using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
            var currentPath = await db.UserSale.Include(u => u.User).FirstOrDefaultAsync(us => us.Id == request.Id);

            if (currentPath == null)
                throw new NotFoundException(nameof(UserSale), request.Id);

            var path = await db.Path.FindAsync(currentPath.IdPath);
            if (path == null)
                throw new NotFoundException("No se encuentra la ruta", currentPath.IdPath);

            //path.Selected = false;
            //currentPath.Visited = true;
            await db.SaveChangesAsync(cancellationToken);

            //Enviar correo con las ventas realizadas
            var usersToNotificate = await db.User.Where(el => el.Aproved && el.UserType == Domain.Enums.UserType.Admin).ToListAsync();
            var sales = await db.Sale
                .Include(p => p.Products)
                .ThenInclude(p => p.Product)
                .Where(s => s.IdUserSale == currentPath.Id).ToListAsync();

            foreach (var sale in sales)
                sale.StoreVisited = await db.Store.FirstOrDefaultAsync(s => s.Id == sale.IdStore);

            if (usersToNotificate.Count > 0)
                _ = mediator.Publish(new DeallocatePathNotificate
                {
                    IdUserSale = currentPath.Id,
                    UserSale = currentPath,
                    Sales = sales,
                    UsersToNotificate = usersToNotificate
                }, cancellationToken);

            return new DeallocatePathResponse();
        }
    }
}
