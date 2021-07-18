using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore
{
    public class DeallocateStoreCommand : IRequest<DeallocateStoreResponse>
    {
        public int Id { get; set; }
    }
}
