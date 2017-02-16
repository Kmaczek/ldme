using System.ComponentModel.DataAnnotations;

namespace Ldme.Models.Dtos
{
    public class LoginDto
    {
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        public string Email { get; set; }

        [MinLength(3)]
        public string Password { get; set; }
    }
}
