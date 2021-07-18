using MediatR;

namespace BreadingBread.Application.UseCases.PathStore.Commands.AssignStore
{
    public class AssignStoreCommand : IRequest<AssignStoreResponse>
    {
        public int IdPath { get; set; }
        public int IdStore { get; set; }
    }
}
