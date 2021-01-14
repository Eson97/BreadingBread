using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Commands.AddStore
{
    public class AddStoreCommand : IRequest<AddStoreResponse>
    {
        public string Name { get; set; }
        public int IdPath { get; set; }

    }
}
