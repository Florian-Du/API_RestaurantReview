using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface INoteInterface
    {
        ICollection<Note> getNotes();

        int getNoteRestaurant(Guid RestaurantId);
        Note getNote(Guid Id);
        bool NoteExist(Guid Id);
        bool CreateNote(Note note);
        bool UpdateNote(Note note);
        bool DeleteNote(Note note);
        bool Save();
    }
}
