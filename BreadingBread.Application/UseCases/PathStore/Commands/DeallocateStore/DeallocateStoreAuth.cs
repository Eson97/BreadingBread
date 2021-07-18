using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore
{
    public class DeallocateStoreAuth : IUserRequest<DeallocateStoreCommand, DeallocateStoreResponse>
    {

        public DeallocateStoreAuth()
        {
        }

        public Task Validate(DeallocateStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
