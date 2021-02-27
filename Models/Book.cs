using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class Book
    {
        [Key][Required]
        public int BookId { get; set; }//generate the primary key

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        //set data validation for ISBN
        [Required][MaxLength(14)][MinLength(14)]
        [RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$", ErrorMessage = "Must be a valid ISBN number in format 13 digits")]
        //Below is another ISBN validation that an TA helped me
        //[RegularExpression(^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$), ErrorMessage = "Must be a valid ISBN number in format 13 digits]
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }//The Classification and Category column in the orginal table is normalized

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Pages { get; set; }

    }

}
