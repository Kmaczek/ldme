using Ldme.Abstract.Interfaces;
using Ldme.Models.Models;
using Microsoft.Extensions.Logging;

namespace Ldme.Logic.Domains
{
    public class FriendDomain
    {
        private readonly IFriendRepository friendRepository;
        private readonly ILogger<FriendDomain> logger;

        public FriendDomain(ILogger<FriendDomain> logger, IFriendRepository friendRepository)
        {
            this.logger = logger;
            this.friendRepository = friendRepository;
        }

        public FriendRequest CreateFriendRequest(int fromPlayer, int toPlayer)
        {
            var request = friendRepository.CreateFriendRequest(fromPlayer, toPlayer);
            friendRepository.SaveChanges();

            return request;
        }
    }
}
