using System.ComponentModel.DataAnnotations;

namespace MyPortivolio.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = " Remember me")]
        public bool RememberMe { get; set; }
    }
}
