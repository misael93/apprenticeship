using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View(Book.books);
        }

        public IActionResult Details(int ID)
        {
            Book book = FindMyBook(ID);
            return View(book);
        }

        public IActionResult Create()
        {
            SelectList authors = new SelectList(Author.authors, "Name", "Name", 0);
            ViewData["Authors"] = authors;
            return View();
        }

        public IActionResult Save(Book book)
        {
            if (ModelState.IsValid)
            {
                book.ID = (Book.books.Count > 0) ? Book.books[Book.books.Count - 1].ID + 1 : 1;
                Book.books.Add(book);
                return View("Index", Book.books);
            }
            SelectList authors = new SelectList(Author.authors, "Name", "Name", 0);
            ViewData["Authors"] = authors;
            return View("Create");
        }

        public IActionResult Edit(int ID)
        {
            Book book = FindMyBook(ID);
            SelectList authors = new SelectList(Author.authors, "Name", "Name", 0);
            ViewData["Authors"] = authors;
            return View(book);
        }

        public IActionResult Update(Book book)
        {
            if (ModelState.IsValid)
            {
                Book b = FindMyBook(book.ID);
                b.Name = book.Name;
                b.Author = book.Author;
                b.Price = book.Price;
                return View("Index", Book.books);
            }
            SelectList authors = new SelectList(Author.authors, "Name", "Name", 0);
            ViewData["Authors"] = authors;
            return View("Edit", book);
        }

        public IActionResult Delete(int ID)
        {
            Book book = FindMyBook(ID);
            Book.books.Remove(book);
            return View("Index", Book.books);
        }

        private Book FindMyBook(int ID)
        {
            return Book.books.Find(item => item.ID == ID);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}