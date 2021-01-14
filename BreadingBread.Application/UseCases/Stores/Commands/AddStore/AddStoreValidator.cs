using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.AddStore
{
    public class AddStoreValidator : AbstractValidator<AddStoreCommand>
    {
        public AddStoreValidator()
        {
            RuleFor(el => el.Name).NotEmpty().MaximumLength(50);
            RuleFor(el => el.IdPath).NotEmpty();

        }
    }
}
