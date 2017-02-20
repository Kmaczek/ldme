using System.ComponentModel.DataAnnotations;

namespace Ldme.Models.Dtos
{
    public class CreateRewardDto
    {
        [MinLength(3)]
        [Required]
        public string Description { get; set; }

        [Range(0, 100)]
        public float GoldPrice { get; set; }

        [Range(0, 100)]
        public float HonorPrice { get; set; }

        public int RewardCreatorId { get; set; }
    }
}
