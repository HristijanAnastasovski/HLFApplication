using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class BuyAccessory
    {
        [Key]
        public int BuyProteinId { get; set; }
        [ScaffoldColumn(false)]
        public int AccessoryId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Invalid credit card number format! We support Visa, MasterCard, American Express, Diners Club, Discover, and JCB cards")]
        public string CreditCardNumber { get; set; }
    }
}