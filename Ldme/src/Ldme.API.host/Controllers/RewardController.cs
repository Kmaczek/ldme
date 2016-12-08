using Ldme.Abstract.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ldme.API.host.Controllers
{
    [Route("api/[controller]")]
    public class RewardController: Controller
    {
        private readonly IFriendRepository friendRepository;
        private readonly ILogger<FriendController> _logger;

        public RewardController(ILogger<FriendController> log)
        {
            _logger = log;
        }
    }
}
