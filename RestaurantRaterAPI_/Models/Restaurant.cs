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

        // Rebuilding this to calsulate off of the ratings we have in the ratings table
        public double Rating 
        { 
            get
            {
                // can write just this after all the logic added below for each rating
                //return FoodRating + EnviromentRating + CleanlinessRating / 3;

                // Calculate a total average score based on ratings
                double totalAverageRating = 0;

                foreach(var rating in Ratings)
                {
                    // below is the same as totalAverageRating = totalAverageRating + rating.AverageRating;
                    totalAverageRating += rating.AverageRating;
                }
                // create a ternary to make sure that the average cannot be divided my 0 and thus run infinitly(only math if there are more than zero ratings) 
                // Return Average of Total if the count is above 0.
                return (Ratings.Count > 0) ? totalAverageRating / Ratings.Count : 0;
            }
        }

        // Average Food Rating
        public double FoodRating
        {
            get
            {
                double totalAverageFoodRating = 0;

                // if followed by single line, curly braces aren't needed
                foreach (var rating in Ratings)
                    totalAverageFoodRating += rating.FoodScore;

                // do not technically need the () unless it's easier to read 
                return Ratings.Count > 0 ? totalAverageFoodRating / Ratings.Count : 0;
            }
        }

        // Average Enviroment Rating
        public double EnviromentRating
        {
            get
            {
                // Select method loops over rating to pull all of the EnviromentScores
                IEnumerable<double> scores = Ratings.Select(rating => rating.EnviromentScore);

                double totalEnviromentScore = scores.Sum();
                return Ratings.Count > 0 ? totalEnviromentScore / Ratings.Count : 0;
            }
        }


        // Average Clinliness Rating
        public double CleanlinessRating
        {
            get
            {
                var totalScore = Ratings.Select(r => r.CleanlinessScore).Sum();
                return (Ratings.Count > 0) ? totalScore / Ratings.Count : 0;
            }
        }

        // or as
        //public double CleanlinessRating
        //{
        //    get
        //    {
        //        return (Ratings.Count > 0) ? Ratings.Select()
        //    }
        //}

        // or can write like so
        //public double ClinlinessRating
        //{
        //    get
        //    {
        //        double totalAverageClinlinessRating = 0;

        //        foreach (var rating in Ratings)
        //        {
        //            totalAverageClinlinessRating += rating.CleanlinessScore;
        //        }
        //        return (Ratings.Count > 0) ? totalAverageClinlinessRating / Ratings.Count : 0;
        //    }
        //}



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


        // All of the associated Rating objects from the database
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

    }
}