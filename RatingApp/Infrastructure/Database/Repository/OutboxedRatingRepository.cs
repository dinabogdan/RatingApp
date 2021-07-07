using RatingApp.Infrastructure.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RatingApp.Infrastructure.Database.Repository
{
    public class OutboxedRatingRepository : IRatingRepository
    {
        private readonly RatingContext _ratingContext;

        public OutboxedRatingRepository(RatingContext ratingContext)
        {
            _ratingContext = ratingContext;
        }

        public void Add(Rating rating)
        {
            using (_ratingContext)
            {

                var ratings = _ratingContext.Ratings
                    .Where(r => r.ProductId == rating.ProductId)
                    .ToList();

                var ratingSum = ratings
                    .Sum(r => r.Value);

                var newRatingAverage = ((decimal)(ratingSum + rating.Value)) / ratings.Count;

                var toBePublishedEvent = new OutboxedEvent
                {
                    Type = "RATING_CHANGED",
                    AggregateId = rating.ProductId,
                    AggregateType = "ProductRatingChanged",
                    OccurredAt = new DateTime(),
                    Payload = Encoding.ASCII.GetBytes(new AverageRatingChanged { ProductId = rating.ProductId, Value = newRatingAverage }.ToJson()),
                    PayloadContentType = "application/json",
                    PayloadSchemaId = "1",
                    PayloadSchema = "json.rating",
                    Metadata = "",
                    CreatedAt = new DateTime()
                };

                _ratingContext.Ratings.Add(rating);
                _ratingContext.OutboxedEvents.Add(toBePublishedEvent);

                _ratingContext.SaveChanges();
            }
        }

        public List<Rating> FindProductRatings(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
