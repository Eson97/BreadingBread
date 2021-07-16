using BreadingBread.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserTokens = new HashSet<UserToken>();
            UserSales = new HashSet<UserSale>();
        }

        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public UserType UserType { get; set; }
        public bool Aproved { get; set; }
        public string TokenConfirmacion { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime LockoutEnd { get; set; }
        public string NormalizedUserName { get; set; }
        public string Name { get; set; }

        public virtual Path Path { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
        public virtual ICollection<UserSale> UserSales { get; set; }
    }
}
