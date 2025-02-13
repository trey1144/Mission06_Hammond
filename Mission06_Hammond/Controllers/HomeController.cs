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
            return View(); // return the view
        }

        [HttpPost]
        public IActionResult MovieForm(Form response) // pass the instance of Form and the response data
        {
            _context.Forms.Add(response); // add record to the database
            _context.SaveChanges(); // save changes to the database

            return View("Index", response); // return the view
        }

    }
}
