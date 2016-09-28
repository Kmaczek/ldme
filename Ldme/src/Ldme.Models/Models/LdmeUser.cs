using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ldme.Models.Models
{
    public class LdmeUser : IdentityUser
    {
        public Player Player { get; set; }
    }
}
