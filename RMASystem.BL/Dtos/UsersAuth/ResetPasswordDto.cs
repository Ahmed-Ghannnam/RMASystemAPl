using System.ComponentModel.DataAnnotations;

namespace RMASystem.APIs
{
    public class ResetPasswordDto
    {
        [Required]
        [Display(Name = "New password")]
        public string NewPassword { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}