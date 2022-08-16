using System.ComponentModel.DataAnnotations;

namespace MyPortivolio.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = " Comfirm Password")]
        [Compare("Password", ErrorMessage = " Comfimed Password must match each Other.")]
        public string ConfirmPassword { get; set; }

    }
}
