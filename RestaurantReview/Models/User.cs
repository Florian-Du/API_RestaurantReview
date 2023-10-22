using System.Security.Cryptography;
using System.Text;

namespace RestaurantReview.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Note>? Notes {  get; set; }
        public ICollection<Response>? Responses { get; set; } 
    }
}
