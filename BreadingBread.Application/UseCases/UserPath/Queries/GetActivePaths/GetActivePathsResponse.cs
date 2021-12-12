using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.UserPath.Queries.GetActivePaths
{
    public class GetActivePathsResponse
    {
        public IList<ActivePathsModel> ActivePaths { get; set; }

    }
    public class ActivePathsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VendorName { get; set; }
    }
}
