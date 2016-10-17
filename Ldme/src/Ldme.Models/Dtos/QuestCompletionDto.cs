using System;
using System.ComponentModel.DataAnnotations;

namespace Ldme.Models.Dtos
{
    public class QuestCompletionDto
    {
        [Required]
        public int CopletedBy { get; set; }

        public DateTime? CompletionDate { get; set; }
    }
}
