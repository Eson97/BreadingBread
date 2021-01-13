using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Paths.Commands.DeletePath
{
    public class DeletePathCommand : IRequest<DeletePathResponse>
    {
        public int Id { get; set; }
    }
}
