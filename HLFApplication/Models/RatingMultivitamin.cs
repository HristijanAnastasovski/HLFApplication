using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class RatingMultivitamin
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        [Range(0, 5)]
        public int Value { get; set; }
        public int MultivitaminId { get; set; }
    }
}