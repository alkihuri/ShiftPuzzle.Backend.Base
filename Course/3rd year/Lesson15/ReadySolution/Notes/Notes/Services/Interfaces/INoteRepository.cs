using Notes.Models;

namespace Notes.Services.Interfaces;

public interface INoteRepository
{
    IEnumerable<Note> GetAllNotes();
    Note GetNoteById(int id);
    void AddNote(Note note);
    void UpdateNote(Note note);
    void DeleteNoteById(int id);
}