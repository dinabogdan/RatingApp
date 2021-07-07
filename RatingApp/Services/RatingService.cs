using RatingApp.Controllers;
using RatingApp.Infrastructure.Database.Model;
using RatingApp.Infrastructure.Database.Repository;
using System;
using System.Linq;

namespace RatingApp.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public AverageRatingDto CalculateAverageRatingForProduct(string productId)
        {
            var ratings = _ratingRepository.FindProductRatings(productId);

            var sum = ratings.Sum(rating => rating.Value);

            return new AverageRatingDto { Value = (decimal)sum / ratings.Count };
        }

        public void SaveRating(RatingDto ratingDto)
        {
            var newRating = new Rating { ProductId = ratingDto.ProductId, Value = ratingDto.Value, CreatedAt = new DateTime() };

            _ratingRepository.Add(newRating);
        }
    }
}
