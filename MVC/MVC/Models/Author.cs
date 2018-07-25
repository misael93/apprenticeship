using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC.Models
{
    public class Author
    {
        public static List<Author> authors = new List <Author>
        {
            new Author { ID = 1, Name = "Alejandro Dumas", DateOfBirth = "24/07/1802", DateOfDeath = "05/12/1870", CountryOfBirth = "Francia" },
            new Author { ID = 2, Name = "Arthur Conan Doyle", DateOfBirth = "22/05/1859", DateOfDeath = "07/07/1930", CountryOfBirth = "Scotland" },
            new Author { ID = 3, Name = "George R. R. Martin", DateOfBirth = "24/07/1802", DateOfDeath = "05/12/1870", CountryOfBirth = "United States" }
        };
        
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        [DisplayName("Birth")]
        public string DateOfBirth { get; set; }
        [DisplayName("Death")]
        public string DateOfDeath { get; set; }
        [DisplayName("Country")]
        public string CountryOfBirth { get; set; }
    }
}
