using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_userRepository.GetUsers());
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get user from database. {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{email}")]
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

        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                _userRepository.LoginAsync(loginDto);
                return Ok();
            }

            return Unauthorized();
        }
    }
}
