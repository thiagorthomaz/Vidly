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


        public ActionResult Edit(int id) {


            return Content("ID: " + id);

        }


        /**
         * ? = optional
         */
        public ActionResult Index(int? pageIndex, string sortBy) {


            if (!pageIndex.HasValue) {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy)) {
                sortBy = "Name";
            }

            List<Movie> list = List();
            
            return View(list);

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

    }
}