using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: /Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Shrek!" };
            
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


            var Movies = new List<Movie>
            {
                    new Movie { Id = 1, Name = "Shrek" },
                    new Movie { Id = 2, Name = "Wall-e" }
            };

            return Movies;

        }

        public Movie findById(int _Id)
        {

            List<Movie> Movies = List();
            Movie Movie = Movies.Find(x => x.Id == _Id);
            return Movie;

        }

    }
}