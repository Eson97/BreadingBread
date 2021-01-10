namespace BreadingBread.Domain.Entities
{
    public class UserToken : BaseEntity
    {
        public int IdUser { get; set; }
        public string RefreshToken { get; set; }

        public virtual User UserNavigation { get; set; }
    }
}
