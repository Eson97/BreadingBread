using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<AddProductResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
