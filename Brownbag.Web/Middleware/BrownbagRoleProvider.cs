using System;
using System.Collections.Generic;
using System.Linq;
using Brownbag.Data.Models;
using Brownbag.Web.Middleware;
using Brownbag.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Brownbag.Web.Middleware {
    public class BrownbagRoleProvider: IBrownbagRoleProvider {
        private readonly ApplicationDataContext db;

        public BrownbagRoleProvider (ApplicationDataContext context) {
            db = context;
        }

        public string[] GetRolesForUser(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                //db.Use
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r.Name;
                if (roles != null)
                    return roles.ToArray();
                else
                    return new string[] { };
            }
            return new string[] { };
        }
        public IList<GuidLookupViewModel> GetRolesForUserManagement(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r;
                if (roles != null)
                    return roles.Select(r => new GuidLookupViewModel { Value = r.Name, ID = r.Id }).ToList();
                else
                    return new List<GuidLookupViewModel>();
            }
            return new List<GuidLookupViewModel>();
        }
        public string GetRolesForUserFlat(string username) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));
            if (user != null) {
                var roles = from ur in user.Roles
                from r in db.Roles
                where ur.RoleId.Equals(r.Id)
                select r.Name;
                if (roles != null)
                    return roles.ToString();
                else
                    return "";
            }
            return "";
        }

        public string[] GetUsersInRole(string roleName) {
            var roleID = db.Roles
                .Where(role => role.Name == roleName)
                .FirstOrDefault();

            var users = db.Users.Where(x => x.Roles.Where(a => a.RoleId.Equals(roleID.Id)).Any()).Select(x => x.UserFullName).ToArray();
            return users;
        }

        public bool IsUserInRole(string username, string roleName) {
            User user = db.Users.Include(a => a.Roles).FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));

            var roles = from ur in user.Roles
            from r in db.Roles
            where ur.RoleId.Equals(r.Id)
            select r.Name;
            if (user != null)
                return roles.Any(r => r.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            else
                return false;
        }

        // //    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        // //    {
        // //      throw new NotImplementedException();
        // //    }

        // //    public override bool RoleExists(string roleName)
        // //    {
        // //      throw new NotImplementedException();
        // //    }
        public Guid GetUserId(string username) {
            User user = db.Users.FirstOrDefault(u => u.UserName.Equals(username, StringComparison.CurrentCultureIgnoreCase));

            if (user != null)
                return user.Id;
            else
                return Guid.Parse("00000000-0000-0000-0000-000000000000");
        }
    }
}