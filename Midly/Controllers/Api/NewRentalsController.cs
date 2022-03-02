using Midly.Dtos;
using Midly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Midly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto RentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == RentalDto.CustomerId);

            var movies = _context.Movies.Where(
                        m => RentalDto.MovieIds.Contains(m.Id)
                    );

            foreach(var movie in movies)
            {
                if (movie.NumberAvailble == 0)
                    return BadRequest("Movie is not availble.");

                movie.NumberAvailble--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
