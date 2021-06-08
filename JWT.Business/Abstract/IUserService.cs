using JWT.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User getByEmail(string email);
        List<OperationClaim> GetClaim(User user);
    }
}
