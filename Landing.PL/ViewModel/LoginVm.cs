using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModel
{
    public class LoginVm
    {

        
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        
        
    }
}
