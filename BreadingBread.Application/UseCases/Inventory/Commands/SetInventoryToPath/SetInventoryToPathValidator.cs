using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Inventory.Commands.SetInventoryToPath
{
    public class SetInventoryToPathValidator : AbstractValidator<SetInventoryToPathCommand>
    {
        public SetInventoryToPathValidator()
        {
        }
    }
}
