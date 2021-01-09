using FluentValidation;

namespace BreadingBread.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasValidator : AbstractValidator<GetPlagasQuery>
    {
        public GetPlagasValidator()
        {
        }
    }
}
