using System;
using System.Collections.Generic;
using System.Security.Claims;
using Models;

namespace Brownbag.Web.Middleware
{
    public interface IBrownbagRoleProvider
    {
        string[] GetRolesForUser(string username);
        string GetRolesForUserFlat(string username);
        IList<GuidLookupViewModel> GetRolesForUserManagement(string username);
        
    }
}