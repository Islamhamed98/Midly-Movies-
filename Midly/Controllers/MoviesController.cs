using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Midly.ViewModels;
using System.Data.Entity.Validation;

namespace Midly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index"); 

            return View("IndexReadOnly");
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var MovieViewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList()
            }; 
            return View(MovieViewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var movieVieModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList() 
            }; 
            return View("Create",movieVieModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            ModelState["movie.Id"].Errors.Clear();
            if(!ModelState.IsValid)
            {
                var movieViewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };  
                return View("Create", movieViewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var MovieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                    MovieInDb.Name = movie.Name;
                    MovieInDb.ReleaseDate = movie.ReleaseDate;
                    MovieInDb.Genre = movie.Genre;
                    MovieInDb.NumInStock = movie.NumInStock; 
            } 
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}