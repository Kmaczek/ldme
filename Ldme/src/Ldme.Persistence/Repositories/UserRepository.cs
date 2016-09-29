using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Models;

namespace Ldme.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            
        }

        public LdmeUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public LdmeUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(LdmeUser user)
        {
            throw new NotImplementedException();
        }
    }
}
