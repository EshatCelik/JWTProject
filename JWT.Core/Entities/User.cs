﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Entities
{
    public class User:IEntity
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }
        public byte PasswordHash { get; set; }
        public byte PasswordSalt { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
