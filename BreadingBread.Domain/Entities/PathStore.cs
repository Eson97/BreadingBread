namespace BreadingBread.Domain.Entities
{
    public class PathStore : DeleteableEntity
    {
        public int IdPath { get; set; }
        public int IdStore { get; set; }
        public bool Visited { get; set; }

        public virtual Path Path { get; set; }
        public virtual Store Store { get; set; }
    }
}
