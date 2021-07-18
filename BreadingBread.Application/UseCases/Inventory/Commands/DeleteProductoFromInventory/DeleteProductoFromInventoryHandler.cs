using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Commands.DeleteProductoFromInventory
{
    public class DeleteProductoFromInventoryHandler : IRequestHandler<DeleteProductoFromInventoryCommand, DeleteProductoFromInventoryResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteProductoFromInventoryHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteProductoFromInventoryResponse> Handle(DeleteProductoFromInventoryCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await db.Inventory.FindAsync(request.Id);

            if (productToDelete == null)
                throw new NotFoundException(nameof(Domain.Entities.Inventory), request.Id);

            db.Inventory.Remove(productToDelete);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteProductoFromInventoryResponse();
        }
    }
}
