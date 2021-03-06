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

namespace BreadingBread.Application.UseCases.Paths.Commands.EditPath
{
    public class EditPathHandler : IRequestHandler<EditPathCommand, EditPathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public EditPathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<EditPathResponse> Handle(EditPathCommand request, CancellationToken cancellationToken)
        {
            var pathToEdit = await db.Path.FindAsync(request.Id);

            if (pathToEdit == null)
                throw new NotFoundException(nameof(Path), request.Id);

            pathToEdit.Name = request.Name;

            await db.SaveChangesAsync(cancellationToken);
            
            return new EditPathResponse();
        }
    }
}
