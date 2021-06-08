using JWT.Core.DataAccess.EntityFramework;
using JWT.Core.Entities;
using JWT.DataAccess.Abstract;
using JWT.DataAccess.Concreate.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.DataAccess.Concreate.EntityFramework
{
    public class EFUserDal : EntityFrameworkBaseRepository<User, JwtTokenContext>, IUserDal
    {
        public List<OperationClaim> GetCleim(User user)
        {
            throw new NotImplementedException();
        }
    }
}
