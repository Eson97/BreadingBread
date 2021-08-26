using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore
{
    public class DeallocateStoreHandler : IRequestHandler<DeallocateStoreCommand, DeallocateStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeallocateStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeallocateStoreResponse> Handle(DeallocateStoreCommand request, CancellationToken cancellationToken)
        {
            var entity = await db.PathStore
                .Where(el => el.IdStore == request.IdStore && el.IdPath == request.IdPath)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.PathStore), request.IdStore);

            db.PathStore.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeallocateStoreResponse();
        }
    }
}
