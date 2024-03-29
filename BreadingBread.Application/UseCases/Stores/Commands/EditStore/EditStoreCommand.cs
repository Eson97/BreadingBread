using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreCommand : IRequest<EditStoreResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
