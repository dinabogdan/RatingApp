using RatingApp.Infrastructure.Database.Model;
using System.Collections.Generic;

namespace RatingApp.Infrastructure.Database.Repository
{
    public interface IRatingRepository
    {
        public void Add(Rating rating);
        public List<Rating> FindProductRatings(string productId);
    }
}
