using MediatR;
using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.PathStore.Commands.AssignStore
{
    public class AssignStoreCommand : IRequest<AssignStoreResponse>
    {
        public int IdPath { get; set; }
        public IEnumerable<int> IdStores { get; set; }
    }
}
