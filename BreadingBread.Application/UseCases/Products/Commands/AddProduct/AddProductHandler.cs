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

namespace BreadingBread.Application.UseCases.Products.Commands.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddProductHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddProductResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            db.Product.Add(newProduct);
            await db.SaveChangesAsync(cancellationToken);

            return new AddProductResponse();
        }
    }
}
