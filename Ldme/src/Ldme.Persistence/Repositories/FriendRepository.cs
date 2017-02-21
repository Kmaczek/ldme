using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Ldme.Persistence.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly LdmeContext ldmeContext;

        public FriendRepository(LdmeContext context)
        {
            ldmeContext = context;
        }

        public void SaveChanges()
        {
            ldmeContext.SaveChanges();
        }
        
        public void AcceptFriendRequest(int friendRequestId)
        {
            var request = ldmeContext.FriendRequests.FirstOrDefault(x => x.Id == friendRequestId);
            request.Status = FriendRequestStatus.Accepted;
        }

        public void RejectFriendRequest(int friendRequestId)
        {
            var request = ldmeContext.FriendRequests.FirstOrDefault(x => x.Id == friendRequestId);
            request.Status = FriendRequestStatus.Rejected;
        }

        public FriendRequest CreateFriendRequest(int fromPlayerId, int toPlayerId)
        {
            var newFriendRequest = new FriendRequest
            {
                RequestedById = fromPlayerId,
                RequestTargetId = toPlayerId,
                Status = FriendRequestStatus.Pending
            };

            ldmeContext.FriendRequests.Add(newFriendRequest);

            return newFriendRequest;
        }

        public FriendRequest GetFriendRequest(int friendRequestId)
        {
            return ldmeContext.FriendRequests.FirstOrDefault(x => x.Id == friendRequestId);
        }

        public IEnumerable<Player> GetFriends(int playerId)
        {
            var friends =
                ldmeContext.FriendRequests
                    .Where(x => x.Status == FriendRequestStatus.Accepted && x.RequestedById == playerId)
                    .Select(x => x.RequestTarget)
                    .Union(ldmeContext.FriendRequests.Where(
                            x => x.Status == FriendRequestStatus.Accepted && x.RequestTargetId == playerId)
                        .Select(x => x.RequestedBy)).ToList();
            

            return friends;
        }
    }
}
