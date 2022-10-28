using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
