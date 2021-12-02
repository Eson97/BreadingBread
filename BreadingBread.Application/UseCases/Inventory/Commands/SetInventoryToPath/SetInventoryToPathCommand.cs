using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Inventory.Commands.SetInventoryToPath
{
    public class SetInventoryToPathCommand : IRequest<SetInventoryToPathResponse>
    {
        public int IdSaleUser { get; set; }
        public IList<ProductModel> Inventory { get; set; }
    }

    public class ProductModel
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

    }
}
