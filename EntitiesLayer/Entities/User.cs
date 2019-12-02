﻿using EntitiesLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace BookStore.EL.Entities
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public DateTime CreationDateTimeUTC { get; set; }
        public string NickName { get; set; }
        public User() : base()
        {
            CreationDateTimeUTC = DateTime.Now;
        }
    }
}
