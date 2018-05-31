using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class CommentMultivitamin
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        [Display(Name = "Your name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Comment")]
        [MaxLength(50)]
        public string Opinion { get; set; }
        [ScaffoldColumn(false)]
        public int MultivitaminId { get; set; }
    }
}