using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleHandler : IRequestHandler<AddSaleCommand, AddSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;
        private readonly IDateTime dateTime;

        public AddSaleHandler(IBreadingBreadDbContext db, IUserAccessor currentUser, IDateTime dateTime)
        {
            this.db = db;
            this.currentUser = currentUser;
            this.dateTime = dateTime;
        }

        public async Task<AddSaleResponse> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            var userSale = await db.UserSale.FindAsync(request.IdUserSale);
            if (userSale == null)
                throw new NotFoundException(nameof(UserSale), request.IdUserSale);

            var store = await db.Store.FindAsync(request.IdStore);
            if (store == null)
                throw new NotFoundException(nameof(Store), request.IdStore);

            var sale = new Domain.Entities.Sale
            {
                IdStore = request.IdStore,
                IdUserSale = request.IdUserSale,
                Commentary = request.Commentary ?? "",
                Lat = request.Lat,
                Lon = request.Lon,
                Total = request.Total,
                Visited = dateTime.Now
            };

            await db.Sale.AddAsync(sale, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            return new AddSaleResponse { IdSale = sale.Id };
        }
    }
}
