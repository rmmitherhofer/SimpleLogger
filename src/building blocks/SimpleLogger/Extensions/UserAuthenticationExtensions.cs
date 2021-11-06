using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace SimpleLogger.Extensions
{
    public static class UserAuthenticationExtensions
    {
        public static void Authenticate(this HttpContext httpContext)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("id", ""));

            var claimsIdentity = new ClaimsIdentity(claims);

            httpContext.User = new ClaimsPrincipal(claimsIdentity);
        }
    }
}
