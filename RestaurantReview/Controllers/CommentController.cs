using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Dto;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly ICommentInterface _commentInterface;
        private readonly IRestaurantInterface _restaurantInterface;
        private readonly IMapper _mapper;
        public CommentController(ICommentInterface commentInterface, IRestaurantInterface restaurantInterface, IMapper mapper )
        {
            _commentInterface = commentInterface;
            _restaurantInterface = restaurantInterface;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getComments()
        {
            var responses = _mapper.Map<List<CommentDto>>(_commentInterface.GetComments());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpGet("{Id}/Comment")]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getComment(string Id)
        {
            Guid CommentId = Guid.Parse(Id);

            var responses = _mapper.Map<CommentDto>(_commentInterface.getComment(CommentId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpGet("{Id}/commentsRestaurants")]
        public IActionResult GetRestaurantComment(string Id)
        {
            Guid RestaurantId = Guid.Parse(Id);

            if (!_restaurantInterface.RestaurantExist(RestaurantId))
            {
                return NotFound();
            }

            ICollection<CommentDto> comments = _mapper.Map<List<CommentDto>>(_commentInterface.GetCommentRestaurant(RestaurantId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] CommentDto commentCreate)
        {
            if (commentCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            commentCreate.Id = Guid.NewGuid();
            var commentMap = _mapper.Map<Comment>(commentCreate);

            if (!_commentInterface.CreateComment(commentMap))
            {
                ModelState.AddModelError("", "Erreur lors de la création");
                return StatusCode(500, ModelState);
            }

            return Ok("Création réussie");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateRestaurant(string Id, [FromBody] CommentDto updatedComment)
        {
            if (updatedComment == null)
            {
                return BadRequest(ModelState);
            }

            Guid CommentId = Guid.Parse(Id);

            if (CommentId != updatedComment.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_commentInterface.CommentExist(CommentId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var CommentMap = _mapper.Map<Comment>(updatedComment);

            if (!_commentInterface.UpdateComment(CommentMap))
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour de la réponse");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
