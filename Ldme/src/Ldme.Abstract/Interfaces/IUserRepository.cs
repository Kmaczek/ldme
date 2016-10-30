using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Ldme.Abstract.Interfaces
{
    public interface IUserRepository
    {
        void SaveUser(LdmeUser user);
        LdmeUser GetUserById(int id);
        LdmeUser GetUserByEmail(string email);
        IEnumerable<LdmeUser> GetUsers();
        Task<SignInResult> LoginAsync(LoginDto loginData);
        Task<IdentityResult> RegisterAsync(RegistrationDto registrationData);
    }
}
