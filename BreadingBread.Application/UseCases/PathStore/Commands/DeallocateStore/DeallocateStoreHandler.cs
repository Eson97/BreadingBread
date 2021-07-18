using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
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
            var entity = await db.PathStore.FindAsync(request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.PathStore), request.Id);

            db.PathStore.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeallocateStoreResponse();
        }
    }
}
