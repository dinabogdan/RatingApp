using RatingApp.Infrastructure.Database.Model;
using System.Collections.Generic;
using System.Linq;

namespace RatingApp.Infrastructure.Database.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RatingContext _ratingContext;

        public RatingRepository(RatingContext ratingContext)
        {
            _ratingContext = ratingContext;
        }

        public void Add(Rating rating)
        {
            using (_ratingContext)
            {
                _ratingContext.Ratings.Add(rating);
                _ratingContext.SaveChanges();
            }
        }

        public List<Rating> FindProductRatings(string productId)
        {
            using (_ratingContext)
            {
                return _ratingContext.Ratings
                    .Where(rating => rating.ProductId == productId)
                    .ToList();
            }
        }
    }
}
