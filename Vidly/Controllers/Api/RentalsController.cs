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

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto rentalDto) {

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MoviesId.Contains(m.Id));

            foreach (var movie in movies) {

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
