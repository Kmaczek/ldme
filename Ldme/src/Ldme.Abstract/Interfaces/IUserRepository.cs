using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IUserRepository
    {
        LdmeUser GetUserById(int id);
        LdmeUser GetUserByEmail(string email);
        void SaveUser(LdmeUser user);
    }
}
