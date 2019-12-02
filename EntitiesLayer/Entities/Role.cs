using EntitiesLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore.EL.Entities
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
        public DateTime CreationDateTimeUTC { get; set; }
        public Role() : base()
        {
            CreationDateTimeUTC = DateTime.UtcNow;
        }
        public Role(string name) : this()
        {
            Name = name;
        }
    }
}
