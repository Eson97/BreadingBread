using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var currentPath = await db.UserSale.FindAsync(request.IdUserPath);
            if (currentPath == null)
                throw new NotFoundException(nameof(UserSale), request.IdUserPath);
            //TODO probar si al eliminar se eliminan la venta y el detalle de la venta
            db.UserSale.Remove(currentPath);

            await db.SaveChangesAsync(cancellationToken);
            return new DeallocatePathResponse();
        }
    }
}
