using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadHandler : IRequestHandler<DeleteEnfermedadCommand, DeleteEnfermedadResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteEnfermedadHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteEnfermedadResponse> Handle(DeleteEnfermedadCommand request, CancellationToken cancellationToken)
        {
            Enfermedad entity = await db.Enfermedad.FindAsync(request.IdEnferemedad);

            db.Enfermedad.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeleteEnfermedadResponse();
        }
    }
}
