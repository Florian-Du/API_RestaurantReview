using Azure;
using Microsoft.EntityFrameworkCore;
using RestaurantReview.Data;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Repository
{
    public class NoteRepository : INoteInterface
    {
        private readonly DataContext _context;

        public NoteRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNote(Note note)
        {
            _context.Add(note);
            return Save();
        }

        public bool DeleteNote(Note note)
        {
            _context.Remove(note);
            return Save();
        }

        public Note getNote(Guid Id)
        {
            return _context.Notes.Where(n => n.Id == Id).FirstOrDefault();
        }

        public int getNoteRestaurant(Guid RestaurantId)
        {
            ICollection<Note> Notes =  _context.Notes.Where(n => n.Restaurant.Id == RestaurantId).Include(u => u.User).ToList();

            int valeurNote = 0;

            foreach (Note note in Notes)
            {
                valeurNote += note.Value;
            }

            return valeurNote / Notes.Count();
        }

        public ICollection<Note> getNotes()
        {
            return _context.Notes.OrderBy(p => p.Id).Include(u => u.User).ToList();
        }

        public bool NoteExist(Guid Id)
        {
            if (_context.Notes.Any(r => r.Id == Id))
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

        public bool UpdateNote(Note note)
        {
            _context.Update(note);
            return Save();
        }
    }
}
