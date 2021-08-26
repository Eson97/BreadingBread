using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            var toAssing = new List<Domain.Entities.PathStore>();

            foreach (var idStore in request.IdStores)
            {
                var storeExist = await db.Store
                .AnyAsync(el => el.Id == idStore, cancellationToken);

                var pathExist = await db.Path
                                .AnyAsync(el => el.Id == request.IdPath, cancellationToken);

                if (!pathExist)
                    throw new NotFoundException(nameof(Path), request.IdPath);

                if (!storeExist)
                    throw new NotFoundException(nameof(Store), request.IdStores);

                var assigned = await db.PathStore
                .AnyAsync(el => el.IdPath == request.IdPath
                        && el.IdStore == idStore);

                if (!assigned)
                {
                    toAssing.Add(new Domain.Entities.PathStore
                    {
                        IdPath = request.IdPath,
                        IdStore = idStore,
                        Visited = false
                    });
                }
            }

            await db.PathStore.AddRangeAsync(toAssing, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return new AssignStoreResponse();
        }
    }
}
