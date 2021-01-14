using MediatR;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathQuery : IRequest<GetListStoresByPathResponse>
    {
        public int IdPath { get; set; }
    }
}
