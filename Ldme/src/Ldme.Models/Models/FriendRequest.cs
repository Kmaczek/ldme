using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ldme.Models.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }

        [Required]
        public int RequestedById { get; set; }
        [ForeignKey("RequestedById")]
        public Player RequestedBy { get; set; }

        [Required]
        public int RequestTargetId { get; set; }
        [ForeignKey("RequestTargetId")]
        public Player RequestTarget { get; set; }

        public string Status { get; set; } // Pending, Accepted, Rejected
    }

    public static class FriendRequestStatus
    {
        public static string Pending { get; } = "pending";
        public static string Accepted { get; } = "accepted";
        public static string Rejected { get; } = "rejected";
    }
}
