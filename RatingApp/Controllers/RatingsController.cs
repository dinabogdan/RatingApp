using Microsoft.AspNetCore.Mvc;
using RatingApp.Services;

namespace RatingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        public void AddRating([FromBody] RatingDto rating) => _ratingService.SaveRating(rating);

        [HttpGet("{productId}")]
        public ActionResult<AverageRatingDto> Get(string productId)
        {
            return _ratingService.CalculateAverageRatingForProduct(productId);
        }
    }
}
