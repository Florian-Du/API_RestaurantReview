using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface INoteInterface
    {
        ICollection<Note> getNotes();

        int getNoteRestaurant(Guid RestaurantId);
        bool NoteExist(Guid Id);
        bool CreateNote(Note note);
        bool UpdateNote(Note note);
        bool Save();
    }
}
