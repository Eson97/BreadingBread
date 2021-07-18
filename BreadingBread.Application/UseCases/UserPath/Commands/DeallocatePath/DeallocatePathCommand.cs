using MediatR;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathCommand : IRequest<DeallocatePathResponse>
    {
        public int IdUserPath { get; set; }
    }
}
