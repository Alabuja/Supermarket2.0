using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Supermarket.Common.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
