using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Common.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public ApplicationUser()
        {
            UserRoles = new List<ApplicationUserRole>();
        }

        public class Roles
        {
            public const string admin = "Admin";
            public const string Admin = "ADMINISTRATOR";
            public const string storeKeeper = "StoreKeeper";
            public const string StoreKeeper = "STOREKEEPER";
            public const string manager = "Manager";
            public const string Manager = "MANAGER";
        }
    }
}
