using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathQuery : IRequest<GetListStoresByPathResponse>
    {
        public int IdPath { get; set; }
    }
}
