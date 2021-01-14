using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathValidator : AbstractValidator<GetListStoresByPathQuery>
    {
        public GetListStoresByPathValidator()
        {
            RuleFor(el => el.IdPath).NotEmpty();
        }
    }
}
