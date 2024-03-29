using MediatR;
namespace BreadingBread.Application.UseCases.Stores.Commands.SetCoor
{
    public class SetCoorCommand : IRequest<SetCoorResponse>
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
