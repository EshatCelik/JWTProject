using JWT.Core.DataAccess;
using JWT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetCleim(User user);
    }
}
