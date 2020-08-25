using RestaurantRaterAPI_.Models;
using System;
using System.Collections.Generic;
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

        RestaurantDbContext _context = new RestaurantDbContext();

        // -- Create (POST)
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            // ModelState is part of controller, checks for validity, activates when request is good 
            if(ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok();
            }
            // BadRequest and Ok method give us our status codes 200 vs 400 etc
            return BadRequest(ModelState);
        }

        // -- Read (GET)
        // Get by ID

        // Get All

        // -- Update (PUT)

        // -- Delete (DELETE)
    }
}
