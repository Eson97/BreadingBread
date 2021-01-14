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

namespace BreadingBread.Application.UseCases.Stores.Commands.DeleteStore
{
    public class DeleteStoreHandler : IRequestHandler<DeleteStoreCommand, DeleteStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteStoreResponse> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            var storeToDelete = await db.Store.FindAsync(request.Id);

            if (storeToDelete == null)
                throw new NotFoundException(nameof(Store), request.Id);

            db.Store.Remove(storeToDelete);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteStoreResponse();
        }
    }
}
