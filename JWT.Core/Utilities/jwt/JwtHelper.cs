using JWT.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWT.Core.Utilities.jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _Configration { get; }
        private TokenOptions tokenOptions { get; }
        private readonly DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            _Configration = configuration;

            tokenOptions = _Configration.GetSection("TokenOptions").Get<TokenOptions>;

            _accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpression);//token süresi
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha256Signature);
            var jwt = new JwtSecurityToken(

                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new AccessToken()
            {
                Token = token,
                TokenLastTime = _accessTokenExpiration
            };


        }

        public JwtSecurityToken CreateJwtSecurityToken(User user,TokenOptions tokenOption,SigningCredentials
            _signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwtSecurity = new JwtSecurityToken(
                issuer: tokenOption.Issuer,
                audience: tokenOption.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: _signingCredentials

                );
            return jwtSecurity;
        }

        private IEnumerable<Claim>SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var _claims = new List<Claim>();
            _claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            _claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            _claims.Add(new Claim(ClaimTypes.Name, user.Name + user.LastName));

            operationClaims.Select(x => x.Name).ToList().ForEach(role => _claims.Add(new Claim(ClaimTypes.Role, role)));
            return _claims;
        }
      
    }
}
