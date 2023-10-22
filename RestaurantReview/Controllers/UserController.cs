using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReview.Dto;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantReview.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserInterface _userInterface;
        private readonly IMapper _mapper;
        public UserController(IUserInterface userInterfacee, IMapper mapper)
        {
            _userInterface = userInterfacee;
            _mapper = mapper;
        }

        [HttpGet]
        //[ProducesResponseType(200), Type(IEnumerable<Restaurant>)]
        public IActionResult getUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userInterface.getUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userInterface.getUsers().Any(u => u.UserEmail == userCreate.UserEmail))
            {
                ModelState.AddModelError("", "Erreur lors de la création : Email déja utiliser veuiller vous connecter");
                return StatusCode(422, ModelState);
            }

            if (userCreate.Password != userCreate.ConfirmPassword)
            {
                ModelState.AddModelError("", "Erreur lors de la création : Mot de passe pas identique");
                return StatusCode(422, ModelState);
            }



            userCreate.Id = Guid.NewGuid();
            userCreate.Salt = GenerateSalt();
            userCreate.Password = HashPassword(userCreate.Password, userCreate.Salt);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_userInterface.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Erreur lors de la création");
                return StatusCode(500, ModelState);
            }

            return Ok("Création réussie");
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateUser(string Id, [FromBody] UserDto updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }

            Guid UserId = Guid.Parse(Id);

            if (UserId != updatedUser.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_userInterface.UserExist(UserId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var UserMap = _mapper.Map<User>(updatedUser);

            if (!_userInterface.UpdateUser(UserMap))
            {
                ModelState.AddModelError("", "Erreur lors de la mise à jour de la réponse");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(string Id)
        {
            Guid UserId = Guid.Parse(Id);

            if (!_userInterface.UserExist(UserId))
            {
                return NotFound();
            }

            var UserToDelete = _userInterface.getUser(UserId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userInterface.DeleteUser(UserToDelete))
            {
                ModelState.AddModelError("", "Erreur lors de la suppression du commentaire");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        private byte[] GenerateSalt()
        {
            // Générer un sel aléatoire de 32 octets (256 bits)
            byte[] sel = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(sel);
            }
            return sel;
        }

        private string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Concaténer le mot de passe et le sel
                byte[] motDePasseSel = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();

                // Calculer le hachage SHA-256
                byte[] hash = sha256.ComputeHash(motDePasseSel);

                // Retourner le hachage sous forme de chaîne hexadécimale
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

    }
}

