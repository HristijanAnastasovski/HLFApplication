using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class Multivitamin
    {
        [Key]
        public int MultivitaminId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Products in stock")]
        public int NumberOfProductsInStock { get; set; } // number of this product in stock
        [Required]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string ImageURL { get; set; }
        public List<RatingMultivitamin> Ratings { get; set; }
        public List<CommentMultivitamin> Comments { get; set; }

        public Multivitamin()
        {
            Comments = new List<CommentMultivitamin>();
            Ratings = new List<RatingMultivitamin>();
        }
    }
}