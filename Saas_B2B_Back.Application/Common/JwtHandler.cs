using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Saas_B2B_Back.Application.Common
{
    public class JwtHandler
    {
        #region ctor
        private readonly AppSetting _appSetting;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        private readonly byte[] _buffer;

        public JwtHandler(AppSetting appSetting)
        {
            _appSetting = appSetting;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _buffer = Encoding.UTF8.GetBytes(_appSetting.Authentication.SecurityKey);
        }
        #endregion


        public string Create(ClaimsIdentity claims, DateTime expires)
        {

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _appSetting.Authentication.Issuer,
                Audience = _appSetting.Authentication.Audience,
                Expires = expires,
                Subject = claims,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_buffer),
                    SecurityAlgorithms.HmacSha256Signature,
                    SecurityAlgorithms.Sha512Digest)
            };

            var secretString = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            var parts = _jwtSecurityTokenHandler.WriteToken(secretString).Split(".");

            var token = _jwtSecurityTokenHandler.WriteToken(secretString);
            return token;
        }

       
    }
}
