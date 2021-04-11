using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> GetClaims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static string GetName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaims(ClaimTypes.Name).Count > 0 ? claimsPrincipal?.GetClaims(ClaimTypes.Name)[0] : null;

        }
        public static string GetIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaims(ClaimTypes.NameIdentifier).Count>0? claimsPrincipal?.GetClaims(ClaimTypes.NameIdentifier)[0]:null;
        }
        public static string GetEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaims(ClaimTypes.Email).Count > 0 ? claimsPrincipal?.GetClaims(ClaimTypes.Email)[0] : null;

        }
        public static List<string> GetClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.GetClaims(ClaimTypes.Role);
        }
    }
}
