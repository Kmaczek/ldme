using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity;

namespace Ldme.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LdmeContext _context;
        private readonly SignInManager<LdmeUser> _signInManager;
        private readonly UserManager<LdmeUser> _userManager;
        public UserRepository(LdmeContext context, SignInManager<LdmeUser> signInManager, UserManager<LdmeUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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

        public async Task<SignInResult> LoginAsync(LoginDto loginData)
        {
            return await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, true, false);
        }

        public async void RegisterAsync(RegistrationDto registrationData)
        {
            await _userManager.CreateAsync(new LdmeUser()
            {
                UserName = registrationData.Email,
                Email = registrationData.Email
            }, registrationData.Password);
        }
    }
}
