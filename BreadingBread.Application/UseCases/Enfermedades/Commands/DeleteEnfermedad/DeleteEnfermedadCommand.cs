using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadCommand : IRequest<DeleteEnfermedadResponse>
    {
        public int IdEnferemedad;
    }
}
