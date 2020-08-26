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
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // Create new ratings
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating(Rating model)
        {
            if (model == null)
            {
                return BadRequest("Your request body cannot be empty.");
            }
            // Check to see if the model is NOT valid, bang makes it "If it is not modelState.IsValid, so checks if false
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Find the targeted restaurant
            var restaurant = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurant == null)
            {
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist.");
            }

            // The restaurant isn't null, so we can successfully rate it
            _context.Ratings.Add(model);
            // Check to make sure it updated 
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You rated {restaurant.Name} successfully!");
            }
            // Backup error message in case the above fails
            return InternalServerError();
        }


        // Get all ratings
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Rating> ratings = await _context.Ratings.ToListAsync();
            return Ok(ratings);
        }

        // Get a rating by ID
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {

            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating != null)
            {
                return Ok(rating);
            }
            return NotFound();
        }

        // Get All Ratings for a specific restaurant by the restaurant ID


        // Update Rating
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRating([FromUri] int id, [FromBody] Rating updatedRating)
        {
            if (ModelState.IsValid)
            {
                Rating rating = await _context.Ratings.FindAsync(id);

                if (rating != null)
                {
                    rating.FoodScore = updatedRating.FoodScore;
                    rating.EnviromentScore = updatedRating.EnviromentScore;
                    rating.CleanlinessScore = updatedRating.CleanlinessScore;

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }


        // Delete Rating
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRatingById(int id)
        {
            Rating rating = await _context.Ratings.FindAsync(id);

            if (rating == null)
            {
                return NotFound();
            }

            _context.Ratings.Remove(rating);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The ratin was deleted.");
            }

            return InternalServerError();
        }


    }
}
