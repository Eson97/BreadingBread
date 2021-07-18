using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.PathStore.Commands.AssignStore
{
    public class AssignStoreHandler : IRequestHandler<AssignStoreCommand, AssignStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AssignStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AssignStoreResponse> Handle(AssignStoreCommand request, CancellationToken cancellationToken)
        {
            var storeExist = await db.Store
                .AnyAsync(el => el.Id == request.IdStore, cancellationToken);

            var pathExist = await db.Path
                            .AnyAsync(el => el.Id == request.IdPath, cancellationToken);

            if (!pathExist)
                throw new NotFoundException(nameof(Path), request.IdPath);

            if (!storeExist)
                throw new NotFoundException(nameof(Store), request.IdStore);

            var assigned = await db.PathStore
            .Where(el => el.IdPath == request.IdPath
                    && el.IdStore == request.IdStore)
                    .FirstOrDefaultAsync();

            if (assigned != null)
                return new AssignStoreResponse();

            var toAssign = new Domain.Entities.PathStore
            {
                IdPath = request.IdPath,
                IdStore = request.IdStore,
                Visited = false
            };

            await db.PathStore.AddAsync(toAssign, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return new AssignStoreResponse();
        }
    }
}
