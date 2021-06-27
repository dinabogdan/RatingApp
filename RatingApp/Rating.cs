using System;
using System.Collections.Generic;

#nullable disable

namespace RatingApp
{
    public partial class Rating
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public short Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
