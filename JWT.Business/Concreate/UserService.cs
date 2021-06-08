using JWT.Business.Abstract;
using JWT.Core.Entities;
using JWT.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Concreate
{
    public class UserService : IUserService
    {
        IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User getByEmail(string email)
        {
           return  _userDal.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaim(User user)
        {
            return _userDal.GetCleim(user);
        }

        
    }
}
