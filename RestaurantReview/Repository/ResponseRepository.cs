using RestaurantReview.Data;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Repository
{
    public class ResponseRepository : IResponseInterface
    {
        private readonly DataContext _context;

        public ResponseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateResponse(Response response)
        {
            _context.Add(response);
            return Save();
        }

        public bool DeleteResponse(Response response)
        {
            _context.Remove(response);
            return Save();
        }

        public Response GetResponse(Guid Id)
        {
            return _context.Responses.Where(r => r.Id == Id).FirstOrDefault();
        }

        public ICollection<Response> GetResponses()
        {
            return _context.Responses.OrderBy(p => p.Id).ToList();
        }

        public ICollection<Response> GetResponsesComment(Guid Id)
        {
            return _context.Responses.Where(r => r.Comment.Id == Id).ToList();
        }

        public bool ResponseExist(Guid Id)
        {
            if (_context.Responses.Any(r => r.Id == Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateResponse(Response response)
        {
            _context.Update(response);
            return Save();
        }
    }
}
