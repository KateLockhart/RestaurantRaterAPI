using RestaurantRaterAPI_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI_.Controllers
{
    
    public class RestaurantController : ApiController
    {
        // This is where we build our endpoints for requests and responses, within the class controller
        // Endpoints are methods within the controller

        // Field created to be read and used inside this class to hold the specific values
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // -- Create (POST)
        // Give it an attribute to always make it a post method
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if(model == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }

            // ModelState is part of controller, checks for validity, activates when request is good 
            if(ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok("Restaurant created and added to database.");
            }
            // BadRequest and Ok method give us our status codes 200 vs 400 etc
            return BadRequest(ModelState);
        }

        // -- Read (GET)
        // Get by ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            
            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            return NotFound();
        }
        

        // Get All
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }


        // -- Update (PUT)

        // -- Delete (DELETE)
    }
}
