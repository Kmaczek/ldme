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
        LdmeUser GetUserById(int id);
        IEnumerable<LdmeUser> GetUsers();
        LdmeUser GetUserByEmail(string email);
        void SaveUser(LdmeUser user);
        Task<SignInResult> LoginAsync(LoginDto loginData);
        void RegisterAsync(RegistrationDto registrationData);
    }
}
