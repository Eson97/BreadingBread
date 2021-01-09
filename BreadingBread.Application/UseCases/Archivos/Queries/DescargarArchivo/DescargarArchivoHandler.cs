using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoHandler : IRequestHandler<DescargarArchivoQuery, DescargarArchivoResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IFileService fileService;

        public DescargarArchivoHandler(IBreadingBreadDbContext db, IFileService fileService)
        {
            this.db = db;
            this.fileService = fileService;
        }

        public async Task<DescargarArchivoResponse> Handle(DescargarArchivoQuery request, CancellationToken cancellationToken)
        {
            var token = await db
                .TokenDescargaArchivo
                .SingleOrDefaultAsync(el => el.Token == request.TokenDescarga && el.HashArchivo == request.Hash);

            if (token == null)
                throw new NotAuthorizedException("No autorizado");

            db.TokenDescargaArchivo.Remove(token);
            await db.SaveChangesAsync(cancellationToken);

            bool fileExists = await db.ArchivoUsuario.AnyAsync(el => el.Hash == request.Hash);

            if (!fileExists)
                throw new NotFoundException("Archivo", request.Hash);

            var file = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Hash);

            var stream = fileService.GetStreamFile(request.Hash);

            return new DescargarArchivoResponse
            {
                Archivo = stream,
                ContentType = file.ContentType,
                Nombre = file.Nombre
            };
        }
    }
}