using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyPortivolio.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Message { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string subject { get; set; }

    }
}
