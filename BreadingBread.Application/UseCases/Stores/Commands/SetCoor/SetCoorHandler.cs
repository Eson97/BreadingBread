using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.SetCoor
{
    public class SetCoorHandler : IRequestHandler<SetCoorCommand, SetCoorResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public SetCoorHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<SetCoorResponse> Handle(SetCoorCommand request, CancellationToken cancellationToken)
        {
            var newStoreCoords = await db.Store.FindAsync(request.Id);

            if (newStoreCoords == null)
                throw new NotFoundException(nameof(Store), request.Id);

            if (newStoreCoords.Lat == 0 && newStoreCoords.Long == 0)
            {
                newStoreCoords.Lat = request.Lat;
                newStoreCoords.Long = request.Long;

                await db.SaveChangesAsync(cancellationToken);
            }

            return new SetCoorResponse();
        }
    }
}
