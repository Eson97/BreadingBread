using FluentValidation;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresValidator : AbstractValidator<GetListStoresQuery>
    {
        public GetListStoresValidator()
        {
        }
    }
}
