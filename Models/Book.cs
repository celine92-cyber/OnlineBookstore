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
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }

    }

}
