using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View(Author.authors);
        }

        public IActionResult Details(int ID)
        {
           Author author = FindMyAuthor(ID);
           return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Save(Author author)
        {
            if (ModelState.IsValid)
            {
                author.ID = (Author.authors.Count > 0) ? Author.authors[Author.authors.Count - 1].ID + 1 : 1;
                Author.authors.Add(author);
                return View("Index", Author.authors);
            }
            return View("Create");
        }

        public IActionResult Edit(int ID)
        {
            Author author = FindMyAuthor(ID);
            return View(author);
        }

        public IActionResult Update(Author author)
        {
            if (ModelState.IsValid)
            {
                Author a = FindMyAuthor(author.ID);
                a.Name = author.Name;
                a.DateOfBirth = author.DateOfBirth;
                a.DateOfDeath = author.DateOfDeath;
                a.CountryOfBirth = author.CountryOfBirth;
                return View("Index", Author.authors);
            }
            return View("Edit", author);
        }

        public IActionResult Delete(int ID)
        {
            Author author = FindMyAuthor(ID);
            if (Book.books.Exists(item => item.Author.Equals(author.Name)))
            {
                ViewData["message"] = "Error: Author is assigned to a book.";
                return View("Index", Author.authors);
            }
            Author.authors.Remove(author);
            return View("Index", Author.authors);
        }

        private Author FindMyAuthor(int ID)
        {
            return Author.authors.Find(item => item.ID == ID);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}