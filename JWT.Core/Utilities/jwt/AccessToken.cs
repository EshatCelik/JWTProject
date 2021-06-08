using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Utilities.jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime TokenLastTime { get; set; }
    }
}
