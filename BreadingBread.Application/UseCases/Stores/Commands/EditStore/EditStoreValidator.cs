using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreValidator : AbstractValidator<EditStoreCommand>
    {
        public EditStoreValidator()
        {
            
        }
    }
}
