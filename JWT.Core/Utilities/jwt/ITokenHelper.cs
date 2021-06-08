using JWT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Utilities.jwt
{
   public  interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
