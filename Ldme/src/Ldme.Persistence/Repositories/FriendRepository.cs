using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Abstract.Interfaces;
using Ldme.DB.Setup;
using Ldme.Models.Models;

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

        public void CreateFriendRequest(int fromPlayerId, int toPlayerId)
        {
            var newFriendRequest = new FriendRequest()
            {
                RequestedById = fromPlayerId,
                RequestTargetId = toPlayerId,
                Status = FriendRequestStatus.Pending
            };

            ldmeContext.FriendRequests.Add(newFriendRequest);
        }

        public FriendRequest GetFriendRequest(int friendRequestId)
        {
            return ldmeContext.FriendRequests.FirstOrDefault(x => x.Id == friendRequestId);
        }
    }
}
