using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Queries.GetPathByUser
{
    public class GetPathByUserHandler : IRequestHandler<GetPathByUserQuery, GetPathByUserResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetPathByUserHandler(IBreadingBreadDbContext db, IUserAccessor userAccessor)
        {
            this.db = db;
            this.currentUser = userAccessor;
        }

        public async Task<GetPathByUserResponse> Handle(GetPathByUserQuery request, CancellationToken cancellationToken)
        {
            var assigned = await
                db.UserSale
                .Where(el => el.IdUser == currentUser.UserId && !el.Visited)
                .FirstOrDefaultAsync();

            //Si el usuario no tiene rutas asignadas
            if (assigned == null) return new GetPathByUserResponse();

            var path = await db.Path.FindAsync(assigned.IdPath);
            return new GetPathByUserResponse { Id = path.Id, Name = path.Name, Selected = path.Selected };
        }
    }
}
