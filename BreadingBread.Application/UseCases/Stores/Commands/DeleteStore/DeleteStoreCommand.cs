using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.DeleteStore
{
    public class DeleteStoreCommand : IRequest<DeleteStoreResponse>
    {
        public int Id { get; set; }
    }
}
