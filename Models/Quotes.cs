using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quotes
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "Your Name: ")]
        public string name {get;set;} = null;
        [Required]
        [Display(Name = "Your Quote: ")]
        public string quote {get;set;} = null;
    }
}