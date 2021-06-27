using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Infrastructure.Database.Repository
{
    public interface IRatingRepository
    {
        public void Add(Rating rating);
        public List<Rating> FindProductRatings(string productId);
    }
}
