using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Commands.AddPath
{
    public class AddPathHandler : IRequestHandler<AddPathCommand, AddPathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddPathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddPathResponse> Handle(AddPathCommand request, CancellationToken cancellationToken)
        {
            var newPath = new Path
            {
                Name = request.Name,
                Selected = false,
            };

            db.Path.Add(newPath);
            await db.SaveChangesAsync(cancellationToken);

            return new AddPathResponse();
        }
    }
}
