using Newtonsoft.Json;

namespace RatingApp.Infrastructure.Database.Repository
{
    public class AverageRatingChanged
    {
        public string ProductId { get; set; }
        public decimal Value { get; set; }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}
