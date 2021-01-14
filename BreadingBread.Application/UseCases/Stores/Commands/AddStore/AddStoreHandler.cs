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

namespace BreadingBread.Application.UseCases.Stores.Commands.AddStore
{
    public class AddStoreHandler : IRequestHandler<AddStoreCommand, AddStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddStoreResponse> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            var pathExist = await db.Path.AnyAsync(el => el.Id == request.IdPath);

            if(!pathExist)
                throw new NotFoundException(nameof(Path), request.IdPath);

            var newStore = new Store
            {
                Name = request.Name,
                IdPath = request.IdPath,
                IsDeleted = false,
            };

            db.Store.Add(newStore);
            await db.SaveChangesAsync(cancellationToken);

            return new AddStoreResponse();
        }
    }
}
