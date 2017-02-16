using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ldme.Abstract.Interfaces;
using Ldme.API.host.RequestHandling;
using Ldme.Models;
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
                _logger.LogError($"Cannot get users from database. {e.Message}");
                return this.HandleErrors(e);
            }
        }

        // api/user/damokles
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest(new ErrorDto("User email was not provided"));
                }

                var user = _userRepository.GetUserByEmail(email);

                if (user == null)
                {
                    return NotFound(new ErrorDto($"No user was found under: {email}"));
                }

                return new JsonResult(user);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot get user from database. {e.Message}");
                return this.HandleErrors(e);
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
                    return this.Unauthorized(ErrorStore.UnauthorizedLoginFailed);
                }
                catch (Exception e)
                {
                    _logger.LogError(LdmeLogEvents.Unknown, e, $"Logging in of user {loginData.Email ?? "UNKNOWN"} failed.");
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] RegistrationDto registrationData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _userRepository.RegisterAsync(registrationData).Result;
                    if (result.Succeeded)
                    {
                        var user = _userRepository.GetUserByEmail(registrationData.Email);
                        return Created(this.Request.Path, user);
                    }
                    return BadRequest(new ErrorDto(result));
                }
                catch (Exception e)
                {
                    _logger.LogInformation(LdmeLogEvents.Unknown, e, "Couldnt register user.");
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }
    }
}
