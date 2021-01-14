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

namespace BreadingBread.Application.UseCases.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteProductHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await db.Product.FindAsync(request.Id);

            if (productToDelete == null)
                throw new NotFoundException(nameof(Product), request.Id);

            db.Product.Remove(productToDelete);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteProductResponse();
        }
    }
}
