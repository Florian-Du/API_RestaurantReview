using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface IResponseInterface
    {
        ICollection<Response> GetResponses();
        ICollection<Response> GetResponsesComment(Guid Id);
        bool ResponseExist(Guid Id);
        bool CreateResponse(Response response);
        bool UpdateResponse(Response response);
        bool Save();

    }
}
