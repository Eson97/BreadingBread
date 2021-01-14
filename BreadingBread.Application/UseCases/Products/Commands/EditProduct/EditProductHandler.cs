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

namespace BreadingBread.Application.UseCases.Products.Commands.EditProduct
{
    public class EditProductHandler : IRequestHandler<EditProductCommand, EditProductResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public EditProductHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<EditProductResponse> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var productToEdit = await db.Product.FindAsync(request.Id);

            if (productToEdit == null)
                throw new NotFoundException(nameof(Product), request.Id);

            productToEdit.Name = request.Name;

            await db.SaveChangesAsync(cancellationToken);

            return new EditProductResponse();
        }
    }
}
