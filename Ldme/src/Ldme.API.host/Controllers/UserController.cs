using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ldme.Abstract.Interfaces;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Ldme.Models.ViewModels;
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

        // api/user/damokles
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
        public IActionResult Post([FromBody] LoginDto loginData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _userRepository.LoginAsync(loginData).Result;
                    if (result.Succeeded)
                    {
                        var user = _userRepository.GetUserByEmail(loginData.Email);
                        var userVM = Mapper.Map<UserVM>(user);

                        return Ok(userVM);
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation(e.ToString());
                    return NotFound();
                }
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] RegistrationDto registrationData)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                try
                {
                    result = _userRepository.RegisterAsync(registrationData).Result;
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogInformation(e.ToString());
                    return BadRequest(result.Errors);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
