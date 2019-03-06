using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto rentalDto) {

            if (rentalDto.MoviesId.Count == 0)
            {
                return BadRequest("No movies Id have been given.");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MoviesId.Contains(m.Id)).ToList();

            if (customer == null) {
                return BadRequest("CustomerId is not valid.");
            }

            if (movies.Count == 0)
            {
                return BadRequest("One or more MovieId are invalid.");
            }

            foreach (var movie in movies) {

                if (movie.NumberAvailable == 0) {
                    return BadRequest("Movie " + movie.Name + " is not avaiable.");
                }

                movie.NumberAvailable--;

                var rental = new Rental {
                    Customer = customer,
                    Movie = movie,
                    DateRentend = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok();

        }

    }
}
