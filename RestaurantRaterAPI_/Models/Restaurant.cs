using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI_.Models
{
    // Restaurant Entitiy (the class that gets stored in the database)
    public class Restaurant
    {
        // IDs are great for using with the database primary key, all databases have keys, a way to point to each unique restaurant
        // add an attribute with [], Key is the identifier, key by default is required 
        [Key]
        public int Id { get; set; }

        // use require attribute to make it required (obviously)
        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating { get; set; }


        public bool IsRecommended => Rating > 3.5;
        //{ these are other ways to write this 
        //    get
        //    {
                // as t/f statement
                //return Rating > 3.5;

                // as a ternary
                //return (Rating > 3.5) ? true : false;

                // long/wordy way bleh
                //if (Rating > 3.5)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
           // }
        //}

    }
}