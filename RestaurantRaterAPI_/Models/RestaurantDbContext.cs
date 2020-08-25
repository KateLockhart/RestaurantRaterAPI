using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI_.Models
{
    public class RestaurantDbContext : DbContext
    {
        // Building out the constructor, calling on the base constructor to create a new one
        public RestaurantDbContext() : base("DefaultConnection") { }

        // Created a restaurants property that stores all of the restaurant objects, this is what will be the table in our database
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}