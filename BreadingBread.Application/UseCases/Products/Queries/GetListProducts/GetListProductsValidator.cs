using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Products.Queries.GetListProducts
{
    public class GetListProductsValidator : AbstractValidator<GetListProductsQuery>
    {
        public GetListProductsValidator()
        {
            
        }
    }
}
