using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Products.Commands.EditProduct
{
    public class EditProductValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductValidator()
        {
            RuleFor(el => el.Id).NotEmpty();
            RuleFor(el => el.Name).NotEmpty().MaximumLength(25);
            RuleFor(el => el.Price).NotEmpty().GreaterThan(0);
        }
    }
}
