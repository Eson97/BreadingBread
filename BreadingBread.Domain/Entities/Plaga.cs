using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Plaga : DeleteableEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ReportePlaga> ReportPlaga { get; set; }

    }
}