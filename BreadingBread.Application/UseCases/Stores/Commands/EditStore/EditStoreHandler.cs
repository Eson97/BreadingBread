using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreHandler : IRequestHandler<EditStoreCommand, EditStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public EditStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<EditStoreResponse> Handle(EditStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await db.Store.FindAsync(request.Id, cancellationToken);
            if (store == null)
                throw new NotFoundException(nameof(Store), request.Id);

            store.IsDeleted = false;
            store.Name = request.Name;
            await db.SaveChangesAsync(cancellationToken);

            return new EditStoreResponse();
        }
    }
}
