using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreHandler : IRequestHandler<EditStoreCommand, EditStoreResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public EditStoreHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<EditStoreResponse> Handle(EditStoreCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
