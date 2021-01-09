using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasAuth : IUserRequest<GetPlagasQuery, GetPlagasResponse>
    {
        public GetPlagasAuth()
        {
        }

        public Task Validate(GetPlagasQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
