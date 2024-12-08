using System.ComponentModel.DataAnnotations;

namespace Landing.PL.ViewModel
{
    public class ForgetPasswordVm
    {
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
