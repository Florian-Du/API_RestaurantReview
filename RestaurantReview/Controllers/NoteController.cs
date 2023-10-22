using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Dto;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly INoteInterface _noteInterface;
        private readonly IRestaurantInterface _restaurantInterface;
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;
        public NoteController(INoteInterface noteInterface, IRestaurantInterface restaurantInterface,IUserInterface userInterface, IMapper mapper)
        {
            _noteInterface = noteInterface;
            _restaurantInterface = restaurantInterface;
            _userInterface = userInterface;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getNotes()
        {
            var responses = _mapper.Map<List<NoteDto>>(_noteInterface.getNotes());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpGet("{Id}/RestaurantNote")]
        public IActionResult GetRestaurantNote(string Id)
        {
            Guid RestaurantId = Guid.Parse(Id);

            if (!_restaurantInterface.RestaurantExist(RestaurantId))
            {
                return NotFound();
            }

            var note = _mapper.Map<NoteDto>(_noteInterface.getNoteRestaurant(RestaurantId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(note);
        }

        [HttpGet("{Id}/Note")]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getNote(string Id)
        {
            Guid NoteId = Guid.Parse(Id);

            var responses = _mapper.Map<NoteDto>(_noteInterface.getNote(NoteId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpPost]
        public IActionResult CreateNote([FromQuery] string _UserId, [FromQuery] string _RestaurantId, [FromBody] ResponseDto responseDto)
        {
            if (responseDto == null || _UserId == null || _RestaurantId == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid UserId = Guid.Parse(_UserId);
            Guid RestaurantId = Guid.Parse(_RestaurantId);

            if (_noteInterface.getNotes().Any(u => u.User.Id == UserId && u.Restaurant.Id == RestaurantId))
            {
                ModelState.AddModelError("", "Erreur lors de la création : Vous avez déja noter ce restaurant");
                return StatusCode(422, ModelState);
            }

            responseDto.Id = Guid.NewGuid();

            var NoteMap = _mapper.Map<Note>(responseDto);

            if (_userInterface.UserExist(UserId))
            {
                NoteMap.User = _userInterface.getUser(UserId);
            }
            else
            {
                ModelState.AddModelError("", "Erreur lors de la création : Utilisateur inconnue");
                return StatusCode(422, ModelState);
            }

            if (_restaurantInterface.RestaurantExist(RestaurantId))
            {
                NoteMap.Restaurant = _restaurantInterface.GetRestaurant(RestaurantId);
            }
            else
            {
                ModelState.AddModelError("", "Erreur lors de la création : Le restaurant n'existe pas");
                return StatusCode(422, ModelState);
            }

            if (!_noteInterface.CreateNote(NoteMap))
            {
                ModelState.AddModelError("", "Erreur lors de la création");
                return StatusCode(500, ModelState);
            }

            return Ok("Création réussie");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateNote(string Id, [FromBody] ResponseDto updatedNote)
        {
            if (updatedNote == null)
            {
                return BadRequest(ModelState);
            }

            Guid NoteId = Guid.Parse(Id);

            if (NoteId != updatedNote.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_noteInterface.NoteExist(NoteId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var NoteMap = _mapper.Map<Note>(updatedNote);

            if (!_noteInterface.UpdateNote(NoteMap))
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour de la réponse");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteNote(string Id)
        {
            Guid NoteId = Guid.Parse(Id);

            if (!_noteInterface.NoteExist(NoteId))
            {
                return NotFound();
            }

            var NoteToDelete = _noteInterface.getNote(NoteId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_noteInterface.DeleteNote(NoteToDelete))
            {
                ModelState.AddModelError("", "Erreur lors de la suppression du commentaire");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
