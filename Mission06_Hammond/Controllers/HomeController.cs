using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Hammond.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Hammond.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context; // create a context

        public HomeController(MovieFormContext temp) // constructor
        {
            _context = temp; // set the context
        }

        public IActionResult Index()
        {
            return View(); // return the view
        }

        public IActionResult GetToKnowJoel()
        {
            return View(); // return the view
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .ToList(); // get the list of categories

            return View(new Movies()); // return the view
        }

        [HttpPost]
        public IActionResult MovieForm(Movies response) // pass the instance of Movies and the response data
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // add record to the database
                _context.SaveChanges(); // save changes to the database

                return View("Index", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .ToList(); // get the list of categories

                return View(response); // return the view
            }
        }

        public IActionResult MovieList()
        {
            var forms = _context.Movies
                .Include(x => x.Category)
                .ToList(); // get the list of forms and join the category table

            return View(forms); // return the view
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id); // get the record to edit using the passed id

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList(); // get the list of categories

            return View("MovieForm", recordToEdit); // return the view with the record to edit to the MovieForm
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            _context.Movies.Update(updatedInfo); // the post that updates the record with the updatedInfo passed
            _context.SaveChanges(); // save changes to the database

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id); // get the record to delete using the passed id

            return View(recordToDelete); // return the view with the record to delete
        }

        [HttpPost]
        public IActionResult Delete(Movies recordToDelete)
        {
            _context.Movies.Remove(recordToDelete); // remove the record
            _context.SaveChanges(); // save changes to the database

            return RedirectToAction("MovieList"); // return to the MovieList
        }
    }
}
