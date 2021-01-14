using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathResponse
    {
        public IList<StoreModelByPathId> Stores { get; set; }
    }
    public class StoreModelByPathId
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
