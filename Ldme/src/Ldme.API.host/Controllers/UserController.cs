using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get(string email)
        {
            try
            {
                return new JsonResult(_userRepository.GetUserByEmail(email));
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get user from database. {e.Message}");
                return BadRequest();
            }
        }
    }
}
