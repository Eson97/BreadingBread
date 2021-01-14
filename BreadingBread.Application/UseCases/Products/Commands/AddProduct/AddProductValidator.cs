using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Products.Commands.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(el => el.Name).NotEmpty().MaximumLength(25);
            RuleFor(el => el.Price).NotEmpty().GreaterThan(0);

        }
    }
}
