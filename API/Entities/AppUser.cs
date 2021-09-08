using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

    }
}