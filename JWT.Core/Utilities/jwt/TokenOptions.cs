using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Utilities.jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpression { get; set; }
        public string SecurityKey { get; set; }

    }
}
