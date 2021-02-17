using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class Book
    {
        //Make BookId the primary key... All fields are required
        [Key]
        [Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }

        //Split up the author's name
        [Required]
        public string AuthorFirstName { get; set; }
        //Not required because some authors don't have a middle name
        public string AuthorMiddleName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        //Regular expression that requires this format ###-##########
        [RegularExpression("[0-9]{3}-[0-9]{10}")]
        public string ISBN { get; set; }
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
    }   

}
