using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Brownbag.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {

        }

        public string UserFullName { get; set; }

        /// Add back legacy Virtuals to support old Identity Style Queries

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<Guid>> Roles { get; } = new List<IdentityUserRole<Guid>>();
    }
}