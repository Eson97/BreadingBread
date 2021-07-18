using MediatR;

namespace BreadingBread.Application.UseCases.UserPath.Commands.AssignPath
{
    public class AssignPathCommand : IRequest<AssignPathResponse>
    {
        public int IdPath { get; set; }
        public int IdUser { get; set; }
    }
}
