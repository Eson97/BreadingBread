using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Paths.Commands.DeletePath
{
    public class DeletePathHandler : IRequestHandler<DeletePathCommand, DeletePathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeletePathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeletePathResponse> Handle(DeletePathCommand request, CancellationToken cancellationToken)
        {
            var pathToDelete = await db.Path.FindAsync(request.Id);

            if (pathToDelete == null)
                throw new NotFoundException(nameof(Path), request.Id);

            db.Path.Remove(pathToDelete);
            await db.SaveChangesAsync(cancellationToken);

            return new DeletePathResponse();
        }
    }
}
