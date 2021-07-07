using RatingApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Services
{
    public interface IRatingService
    {
        public void SaveRating(RatingDto ratingDto);
        public AverageRatingDto CalculateAverageRatingForProduct(string productId);
    }
}
