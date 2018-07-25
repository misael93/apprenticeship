using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Book
    {
        public static List<Book> books = new List<Book>
        {
            new Book { ID = 1, Name = "El conde de Montecristo", Author = "Alejandro Dumas", Price = 200.00f },
            new Book { ID = 2, Name = "Las aventuras de Sherlock Holmes", Author = "Arthur Conan Doyle", Price = 100.50f },
            new Book { ID = 3, Name = "Juego de Tronos", Author = "George R. R. Martin", Price = 300.00f }
        };

        public int ID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; }
        [Required]
        [Range(0, 10000.00)]
        public float Price { get; set; }
    }
}
