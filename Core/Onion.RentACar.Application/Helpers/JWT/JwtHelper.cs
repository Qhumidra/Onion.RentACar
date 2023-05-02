using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Onion.RentACar.Application.Extentions;
using Onion.RentACar.Application.Helpers.Encyption;
using Onion.RentACar.Domain.Entities;

namespace Onion.RentACar.Application.Helpers.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public AccessToken CreateToken(AppUser appUser, List<AppRole> appRoles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, appUser, signingCredentials, appRoles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser appUser,
            SigningCredentials signingCredentials, List<AppRole> appRoles)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(appUser, appRoles),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AppUser appUser, List<AppRole> appRoles)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(appUser.Id.ToString());
            claims.AddName($"{appUser.Name} {appUser.Surname}");
            claims.AddRoles(appRoles.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
