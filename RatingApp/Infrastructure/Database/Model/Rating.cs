using System;

#nullable disable

namespace RatingApp.Infrastructure.Database.Model
{
    public partial class Rating
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public short Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
