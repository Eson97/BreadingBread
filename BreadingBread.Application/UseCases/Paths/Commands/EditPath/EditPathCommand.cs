using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Paths.Commands.EditPath
{
    public class EditPathCommand : IRequest<EditPathResponse>
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
