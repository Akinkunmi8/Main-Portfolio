using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortivolio.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string FileUrl { get; set; }
        [NotMapped]
        public IFormFile FileDocs { get; set; }
        public string Date { get; set; }
       
    }
}
