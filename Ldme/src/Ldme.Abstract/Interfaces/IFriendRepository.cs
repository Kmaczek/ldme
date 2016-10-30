using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ldme.Models.Models;

namespace Ldme.Abstract.Interfaces
{
    public interface IFriendRepository
    {
        void SaveChanges();
        void AcceptFriendRequest(int friendRequestId);
        void RejectFriendRequest(int friendRequestId);
        void CreateFriendRequest(int fromPlayerId, int toPlayerId);
        FriendRequest GetFriendRequest(int friendRequestId);
    }
}
