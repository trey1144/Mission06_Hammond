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

            return View(); // return the view
        }

        [HttpPost]
        public IActionResult MovieForm(Movies response) // pass the instance of Form and the response data
        {
            _context.Movies.Add(response); // add record to the database
            _context.SaveChanges(); // save changes to the database

            return View("Index", response); // return the view
        }

        public IActionResult MovieList()
        {
            var forms = _context.Movies
                .Include(x => x.Category)
                // .OrderBy(x => x.Title)
                .ToList();

            return View(forms); // return the view
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieForm", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieID == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movies recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
