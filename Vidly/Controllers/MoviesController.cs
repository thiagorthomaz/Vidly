using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController() {
            this._context = new ApplicationDbContext();

        }
        // GET: /Movies/Random
        public ActionResult Random()
        {

            var movie = this.findById(1);
            
            var c = new CustomersController();
            List<Customer> customers = c.List();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id) {

            var movie = findById(id);
            var modelView = new MovieFormViewModel {
                Movie = movie,
                Genres = this._context.Genres.ToList()
            };

            return View("MovieForm", modelView);

        }


        /**
         * ? = optional
         */
        public ActionResult Index(int? pageIndex, string sortBy) {

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else {
                return View("ReadOnlyList");
            }
           
            

            //return Content(String.Format("pageIndex={0}&sorBy={1}", pageIndex, sortBy));

        }
        

        [Route("movies/released/year/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Details(int id)
        {

            Movie Movie = findById(id);

            return View(Movie);
        }

        public List<Movie> List()
        {

            var movies = this._context.Movies.Include(m => m.Genre).ToList();
            return movies;

        }

        public Movie findById(int _Id)
        {
            var movie = this._context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == _Id);
            return movie;

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = this._context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = this._context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                this._context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = this._context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.Stock = movie.Stock;
                movieInDb.ReleaseDate = movie.ReleaseDate;

            }

            this._context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }
}