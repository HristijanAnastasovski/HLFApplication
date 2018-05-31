using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class Protein
    {
        [Key]
        public int ProteinId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name="Products in stock")]
        public int NumberOfProductsInStock { get; set; } // number of this product in stock
        [Required]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [Required]
        public string ImageURL { get; set; }
        //[ScaffoldColumn(false)]
        //public bool OnSale { get; set; }
        //[ScaffoldColumn(false)]
        //public decimal OldPrice { get; set; }
        public List<Rating> Ratings { get; set; }
        public List<Comment> Comments { get; set; }

        public Protein()
        {
            
            Comments = new List<Comment>();
            Ratings = new List<Rating>();
        }
    }
}