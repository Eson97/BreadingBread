using MediatR;

namespace BreadingBread.Application.UseCases.Paths.Commands.AddPath
{
    public class AddPathCommand : IRequest<AddPathResponse>
    {
        public string Name { get; set; }
    }
}
