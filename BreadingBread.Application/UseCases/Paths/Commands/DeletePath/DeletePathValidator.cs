using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Paths.Commands.DeletePath
{
    public class DeletePathValidator : AbstractValidator<DeletePathCommand>
    {
        public DeletePathValidator()
        {
            RuleFor(el => el.Id).NotEmpty();
        }
    }
}
