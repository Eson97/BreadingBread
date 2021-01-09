using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaHandler : IRequestHandler<DeletePlagaCommand, DeletePlagaResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeletePlagaHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeletePlagaResponse> Handle(DeletePlagaCommand request, CancellationToken cancellationToken)
        {
            Plaga entity = await db.Plaga.FindAsync(request.IdPlaga);

            db.Plaga.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeletePlagaResponse();
        }
    }
}
