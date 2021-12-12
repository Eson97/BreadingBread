using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetProductList
{
    public class GetProductListResponse
    {
        public IList<ProductModel> Products { get; set; }
    }
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
