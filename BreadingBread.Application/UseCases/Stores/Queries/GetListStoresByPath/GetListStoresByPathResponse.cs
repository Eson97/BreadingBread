using System.Collections.Generic;

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
        public double Lat { get; set; }
        public double Lon { get; set; }
        public bool Visited { get; set; }
    }
}
