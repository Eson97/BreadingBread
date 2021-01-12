using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Paths.Queries.GetListPath
{
    public class GetListPathResponse
    {
        public IList<PathLookupModel> Paths { get; set; }

    }
    public class PathLookupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
