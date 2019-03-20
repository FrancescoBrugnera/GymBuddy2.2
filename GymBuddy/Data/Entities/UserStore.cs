using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymBuddy.Data.Entities
{
    public class UserStore : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
