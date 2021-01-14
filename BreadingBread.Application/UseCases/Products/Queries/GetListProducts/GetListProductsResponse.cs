using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Products.Queries.GetListProducts
{
    public class GetListProductsResponse
    {
        public IList<ProductModel> Products { get; set; }

    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
