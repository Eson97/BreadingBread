using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresResponse
    {
        public IList<StoreModel> Stores { get; set; }

    }
    public class StoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
