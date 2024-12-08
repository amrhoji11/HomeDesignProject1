using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModel
{
    public class ResetPasswordVm
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }

    }
}
