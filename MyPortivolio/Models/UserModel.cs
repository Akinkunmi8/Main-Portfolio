using Microsoft.AspNetCore.Identity;

namespace MyPortivolio.Models
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }
    }
}
