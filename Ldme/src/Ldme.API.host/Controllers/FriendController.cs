using Ldme.Abstract.Interfaces;
using Ldme.Models.Dtos;
using Ldme.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class FriendController : Controller
    {
        private readonly IFriendRepository friendRepository;
        private readonly ILogger<FriendController> _logger;

        public FriendController(IFriendRepository friendRepository, ILogger<FriendController> log)
        {
            this.friendRepository = friendRepository;
            this._logger = log;
        }

        [HttpPost("request")]
        public IActionResult Post([FromBody]FriendRequestDto friendRequestDto)
        {
            if (ModelState.IsValid)
            {
                friendRepository.CreateFriendRequest(friendRequestDto.FromPlayer, friendRequestDto.ToPlayer);
                friendRepository.SaveChanges();

                return Ok(); // Created
            }

            return BadRequest(ModelState);
        }
    }
}
