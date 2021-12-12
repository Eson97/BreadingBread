using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetProductList
{
    public class GetProductListValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListValidator()
        {
            
        }
    }
}
