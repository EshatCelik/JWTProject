using JWT.Business.Abstract;
using JWT.Core.Entities;
using JWT.Core.Utilities.hashing;
using JWT.Core.Utilities.jwt;
using JWT.DataAccess.Concreate.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Concreate
{
    public class AuthService : IAuthService
    {
        IUserService _userService;
        IAuthService _authService;

        public AuthService(IUserService userService,IAuthService authService)
        {
            _authService = authService;
            _userService = userService;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaim(user);
            var accessToken = _authService.CreateAccessToken(user,claims);
            return accessToken;
        }

        public bool IfUserExists(string email)
        {
            throw new NotImplementedException();
        }

        public User Login(UserLoginDTO userDto)
        {
            throw new NotImplementedException();
        }

        public User Register(UserRegisterDTO userDto, string password)
        {
            byte[] passwordHash,passwordSalt;
            HashingHelper.CreatePasswordHash(password, passwordHash, passwordSalt);

            var user = new User
            {
                Email = userDto.Email,
                Name = userDto.Name,
                LastName = userDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                CreateDate = DateTime.Now
            };
            _userService.Add(user);
            return user;
        }
    }
}
