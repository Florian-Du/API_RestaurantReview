using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Dto;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantInterface _restaurantInterface;
        private readonly INoteInterface _noteInterface;
        private readonly ICommentInterface _commentInterface;
        private readonly IResponseInterface _responseInterface;
        private readonly IMapper _mapper;
        public RestaurantController(IRestaurantInterface restaurantInterface, INoteInterface noteInterface, ICommentInterface commentInterface, IResponseInterface responseInterface, IMapper mapper) 
        {
            _restaurantInterface = restaurantInterface;
            _noteInterface = noteInterface;
            _commentInterface = commentInterface;
            _responseInterface = responseInterface;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getRestaurants()
        {
            var restaurants = _mapper.Map<List<RestaurantDto>>(_restaurantInterface.GetRestaurants());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(restaurants);
        }

        [HttpGet("{Id}")]
        public IActionResult GetRestaurant(string Id)
        {
            Guid RestaurantId = Guid.Parse(Id);

            if(!_restaurantInterface.RestaurantExist(RestaurantId))
            {
                return NotFound();
            }

            var restaurant = _mapper.Map<RestaurantDto>(_restaurantInterface.GetRestaurant(RestaurantId));

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] RestaurantDto restaurantCreate)
        {
            if (restaurantCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_restaurantInterface.GetRestaurants().Any(r => r.Name == restaurantCreate.Name))
            {
                ModelState.AddModelError("", "Erreur lors de la création : Nom du restaurant déja utiliser");
                return StatusCode(422, ModelState);
            }

            restaurantCreate.Id = Guid.NewGuid();

            var userMap = _mapper.Map<Restaurant>(restaurantCreate);

            if (!_restaurantInterface.CreateRestaurant(userMap))
            {
                ModelState.AddModelError("", "Erreur lors de la création");
                return StatusCode(500, ModelState);
            }

            return Ok("Création réussie");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateRestaurant(string Id, [FromBody] RestaurantDto updatedRestaurant)
        {
            if (updatedRestaurant == null)
            {
                return BadRequest(ModelState);
            }

            Guid RestaurantId = Guid.Parse(Id);

            if (RestaurantId != updatedRestaurant.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_restaurantInterface.RestaurantExist(RestaurantId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var RestaurantMap = _mapper.Map<Restaurant>(updatedRestaurant);

            if (!_restaurantInterface.UpdateRestaurant(RestaurantMap))
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour de la réponse");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteRestaurant(string Id)
        {
            Guid RestaurantId = Guid.Parse(Id);

            if (!_restaurantInterface.RestaurantExist(RestaurantId))
            {
                return NotFound();
            }

            var RestaurantToDelete = _restaurantInterface.GetRestaurant(RestaurantId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_restaurantInterface.DeleteRestaurant(RestaurantToDelete))
            {
                ModelState.AddModelError("", "Erreur lors de la suppression du commentaire");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
