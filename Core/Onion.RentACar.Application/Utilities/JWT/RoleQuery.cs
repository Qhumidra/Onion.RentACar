using Microsoft.AspNetCore.Http;
using Onion.RentACar.Application.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.RentACar.Application.Utilities.JWT
{
    public class RoleQuery
    {
        private IHttpContextAccessor _httpContextAccessor;
        public RoleQuery()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        public bool Role(string[] _roles)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return true;
                }
            }
            throw new Exception("Yetkiniz yok.");
        } 
    }
}
