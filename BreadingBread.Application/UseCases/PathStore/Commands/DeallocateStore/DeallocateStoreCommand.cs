using MediatR;

namespace BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore
{
    public class DeallocateStoreCommand : IRequest<DeallocateStoreResponse>
    {
        public int IdStore { get; set; }
        public int IdPath { get; set; }
    }
}
