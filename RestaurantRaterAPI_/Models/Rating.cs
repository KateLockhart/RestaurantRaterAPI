using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI_.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key (Restaurant Key)
        // When we set up a Foreign Key we need both a foreign key and navigation property(tells us which table to go to) 
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }
        // This is a foreign key navigation property, used to connect the two database tables
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double EnviromentScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double CleanlinessScore { get; set; }

        // Add all scores and get the average out of 10
        public double AverageRating
        {
            get
            {
                var totalScore = FoodScore + EnviromentScore + CleanlinessScore;
                return totalScore / 3;
            }
        }
    }
}