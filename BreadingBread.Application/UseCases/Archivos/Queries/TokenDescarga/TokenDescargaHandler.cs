using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Archivos.Queries.TokenDescarga
{
    public class TokenDescargaHandler : IRequestHandler<TokenDescargaQuery, TokenDescargaResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IRandomGenerator random;

        public TokenDescargaHandler(IBreadingBreadDbContext db, IRandomGenerator random)
        {
            this.db = db;
            this.random = random;
        }

        public async Task<TokenDescargaResponse> Handle(TokenDescargaQuery request, CancellationToken cancellationToken)
        {
            var tokenNuevo = new TokenDescargaArchivo
            {
                HashArchivo = request.HashArchivo,
                Token = random.Guid()
            };

            db.TokenDescargaArchivo.Add(tokenNuevo);
            await db.SaveChangesAsync(cancellationToken);

            return new TokenDescargaResponse
            {
                TokenDescarga = tokenNuevo.Token
            };
        }
    }
}