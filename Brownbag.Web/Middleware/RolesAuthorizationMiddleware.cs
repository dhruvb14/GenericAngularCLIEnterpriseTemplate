using Brownbag.Data.Models;
using Brownbag.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Brownbag.Web.Middleware
{
    public class RolesAuthorizationMiddleware : IMiddleware {
        private readonly ApplicationDataContext _db;

        public RolesAuthorizationMiddleware(ApplicationDataContext db) {
            _db = db;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
            try {
                User user = _db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(context.User.Identity.Name, StringComparison.CurrentCultureIgnoreCase));
                if (user != null) {
                    var roles = from ur in user.Roles
                    from r in _db.Roles
                    where ur.RoleId.Equals(r.Id)
                    select r.Name;

                    var UserRoleClaims = roles.Select(i => new Claim(ClaimTypes.Role, i));
                    ((ClaimsIdentity) context.User.Identity).AddClaims(UserRoleClaims);
                    ((ClaimsIdentity) context.User.Identity).AddClaim(new Claim("userId", user.Id.ToString()));
                }
            } catch (Exception e) {
                Console.Write(e);
            }

            await next(context);
        }

    }
    public static class RolesAuthorizationMiddlewareExtensions {
        public static IApplicationBuilder RolesAuthorization(
            this IApplicationBuilder builder) {
            return builder.UseMiddleware<RolesAuthorizationMiddleware>();
        }
    }
}