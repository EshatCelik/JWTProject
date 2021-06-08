using JWT.Core.Entities;
using JWT.Core.Utilities.jwt;
using JWT.DataAccess.Concreate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Abstract
{
    public interface IAuthService
    {
        User Register(UserRegisterDTO userDto, string password);
        User Login(UserLoginDTO userDto);
        bool IfUserExists(string email);
        AccessToken CreateAccessToken(User user,List<OperationClaim> operationClaims);


    }
}
