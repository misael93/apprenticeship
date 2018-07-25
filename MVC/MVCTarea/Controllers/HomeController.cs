using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTarea.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<Book> books = new List<Book>
        {
            new Book { ID = 1, Name = "El conde de Montecristo", Author = "Alejandro Dumas", Price = 200.00f },
            new Book { ID = 2, Name = "Las aventuras de Sherlock Holmes", Author = "Arthur Conan Doyle", Price = 100.50f },
            new Book { ID = 3, Name = "Juego de Tronos", Author = "George R. R. Martin", Price = 300.00f }
        };
        
        public static List<Author> authors = new List <Author>
        {
            new Author { ID = 1, Name = "Alejandro Dumas", DateOfBirth = "24/07/1802", DateOfDeath = "05/12/1870", CountryOfBirth = "Francia" },
            new Author { ID = 1, Name = "Arthur Conan Doyle", DateOfBirth = "22/05/1859", DateOfDeath = "07/07/1930", CountryOfBirth = "Scotland" },
            new Author { ID = 1, Name = "George R. R. Martin", DateOfBirth = "24/07/1802", DateOfDeath = "05/12/1870", CountryOfBirth = "United States" }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books() {
            return View(books);
        }

        public IActionResult Authors() {
            return View(authors);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
