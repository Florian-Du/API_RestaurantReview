﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Dto;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    public class ResponseController : Controller
    {
        private readonly IResponseInterface _responseInterface;
        private readonly IUserInterface _userInterface;
        private readonly ICommentInterface _commentInterface;
        private readonly IMapper _mapper;
        public ResponseController(IResponseInterface responseInterface, IUserInterface userInterface, ICommentInterface commentInterface, IMapper mapper)
        {
            _responseInterface = responseInterface;
            _userInterface = userInterface;
            _commentInterface = commentInterface;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getResponses()
        {
            var responses = _mapper.Map<List<ResponseDto>>(_responseInterface.GetResponses());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpGet("{Id}/Response")]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getResponse(string Id)
        {
            Guid ResponseId = Guid.Parse(Id);

            var responses = _mapper.Map<ResponseDto>(_responseInterface.GetResponse(ResponseId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(responses);
        }

        [HttpPost]
        public IActionResult CreateResponse([FromQuery] string _UserId, [FromQuery] string _CommentId, [FromBody] ResponseDto responseDto)
        {
            if (responseDto == null || _UserId == null || _CommentId == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Guid UserId = Guid.Parse(_UserId);
            Guid CommentId = Guid.Parse(_CommentId);

            responseDto.Id = Guid.NewGuid();

            var responseMap = _mapper.Map<Response>(responseDto);

            if (_userInterface.UserExist(UserId))
            {
                responseMap.User = _userInterface.getUser(UserId);
            }else
            {
                ModelState.AddModelError("", "Erreur lors de la création : Utilisateur inconnue");
                return StatusCode(422, ModelState);
            }

            if (_commentInterface.CommentExist(CommentId))
            {
                responseMap.Comment = _commentInterface.getComment(CommentId);
            }else
            {
                ModelState.AddModelError("", "Erreur lors de la création : Le commentaire n'existe pas");
                return StatusCode(422, ModelState);
            }

            if (!_responseInterface.CreateResponse(responseMap))
            {
                ModelState.AddModelError("", "Erreur lors de la création");
                return StatusCode(500, ModelState);
            }

            return Ok("Création réussie");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateResponse(string Id, [FromBody] ResponseDto updatedResponse)
        {
            if (updatedResponse == null)
            {
                return BadRequest(ModelState);
            }

            Guid ResponseId = Guid.Parse(Id);

            if (ResponseId != updatedResponse.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_responseInterface.ResponseExist(ResponseId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var responseMap = _mapper.Map<Response>(updatedResponse);

            if (!_responseInterface.UpdateResponse(responseMap))
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour de la réponse");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteResponse(string Id)
        {
            Guid ResponseId = Guid.Parse(Id);

            if (!_responseInterface.ResponseExist(ResponseId))
            {
                return NotFound();
            }

            var ResponseToDelete = _responseInterface.GetResponse(ResponseId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_responseInterface.DeleteResponse(ResponseToDelete))
            {
                ModelState.AddModelError("", "Erreur lors de la suppression du commentaire");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
    
}
