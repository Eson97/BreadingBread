using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Paths.Commands.EditPath
{
    public class EditPathValidator : AbstractValidator<EditPathCommand>
    {
        public EditPathValidator()
        {
            RuleFor(el => el.Name).NotEmpty().MaximumLength(20);
            RuleFor(el => el.ID).NotEmpty();
        }
    }
}
