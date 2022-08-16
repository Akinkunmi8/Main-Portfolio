using System.ComponentModel.DataAnnotations;

namespace MyPortivolio.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
