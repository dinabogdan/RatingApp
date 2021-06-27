using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RatingApp.Infrastructure.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {

        private readonly ILogger<RatingsController> _logger;
        private readonly IRatingRepository _ratingRepository;

        public RatingsController(ILogger<RatingsController> logger,
            IRatingRepository ratingRepository)
        {
            _logger = logger;
            _ratingRepository = ratingRepository;
        }

        [HttpGet]
        public ActionResult<string> HelloWorld()
        {
            return "Hello world";
        }

        [HttpPost]
        public void AddRating([FromBody] RatingDto rating)
        {
            var newRating = new Rating { ProductId = rating.ProductId, Value = rating.Value, CreatedAt = new DateTime() };

            _ratingRepository.Add(newRating);
        }

        [HttpGet("{productId}")]
        public IEnumerable<Rating> Get(string productId)
        {
            return _ratingRepository.FindProductRatings(productId);
        }
    }
}
