using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModel
{
    public class RegisterVm
    {
        [Required(ErrorMessage ="UserName is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }





    }
}
