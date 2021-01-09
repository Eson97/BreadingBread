using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoHandler : IRequestHandler<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AgregarArchivoHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarArchivoResponse> Handle(AgregarArchivoCommand request, CancellationToken cancellationToken)
        {
            bool fileExists = await db.ArchivoUsuario.AnyAsync(el => el.Hash == request.Archivo);

            if (!fileExists)
            {
                throw new NotFoundException(nameof(request.Archivo), request.Archivo);
            }

            var archivo = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Archivo);

            //var materialApoyoActividad = new MaterialApoyoActividad
            //{
            //    IdArchivoUsuario = archivo.Id,
            //    IdActividad = request.IdActividad
            //};

            //db.MaterialApoyoActividad.Add(materialApoyoActividad);

            await db.SaveChangesAsync(cancellationToken);

            return new AgregarArchivoResponse
            {
                Hash = request.Archivo
            };
        }
    }
}