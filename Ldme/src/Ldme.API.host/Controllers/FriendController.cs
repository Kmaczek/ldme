using System;
using Ldme.Abstract.Interfaces;
using Ldme.API.host.RequestHandling;
using Ldme.Logic.Domains;
using Ldme.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly FriendDomain friendDomain;
        private readonly ILogger<FriendController> _logger;

        public FriendController(FriendDomain friendDomain, ILogger<FriendController> log)
        {
            this.friendDomain = friendDomain;
            this._logger = log;
        }

        [HttpPost("request")]
        public IActionResult Post([FromBody] FriendRequestDto friendRequestDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: What error is thrown while user is not found
                    var friendRequest = friendDomain.CreateFriendRequest(friendRequestDto.FromPlayer,
                        friendRequestDto.ToPlayer);

                    return Created(this.Request.Path, friendRequest);
                }
                catch (Exception e)
                {
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var friends = friendDomain.GetFriends(id);
                    return Json(friends);
                }
                catch (Exception e)
                {
                    _logger.LogExceptions(e, this);
                    return this.HandleErrors(e);
                }
            }

            return BadRequest(new ErrorDto(ModelState));
        }
    }
}
