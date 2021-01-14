using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.DeleteStore
{
    public class DeleteStoreValidator : AbstractValidator<DeleteStoreCommand>
    {
        public DeleteStoreValidator()
        {
            
        }
    }
}
