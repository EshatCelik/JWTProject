using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.DataAccess.Concreate.DTOs
{
    public class UserRegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string  Name { get; set; }
        public string  LastName { get; set; }
    }
}
