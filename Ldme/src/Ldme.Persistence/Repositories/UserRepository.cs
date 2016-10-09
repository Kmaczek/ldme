using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.Common.Factories;
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
        private readonly PlayerFactory _playerFactory;

        public UserRepository(
            LdmeContext context, 
            SignInManager<LdmeUser> signInManager, 
            UserManager<LdmeUser> userManager,
            PlayerFactory playerFactory)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _playerFactory = playerFactory;
        }

        public LdmeUser GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LdmeUser> GetUsers()
        {
            return _context.Users;
        }

        public LdmeUser GetUserByEmail(string email)
        {
            return _context.Users.First(x => x.Email == email);
        }

        public void SaveUser(LdmeUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<SignInResult> LoginAsync(LoginDto loginData)
        {
            return await _signInManager.PasswordSignInAsync(loginData.Email, loginData.Password, true, false);
        }

        public async Task<IdentityResult> RegisterAsync(RegistrationDto registrationData)
        {
//            if (_context.Users.Any(x => x.Email == registrationData.Email))
//            {
//                return IdentityResult.Failed();
//            }

            return await _userManager.CreateAsync(new LdmeUser()
            {
                UserName = registrationData.Email,
                Email = registrationData.Email,
                Player = _playerFactory.GetInitialPlayer(registrationData.Email)
            }, registrationData.Password);
        }
    }
}
