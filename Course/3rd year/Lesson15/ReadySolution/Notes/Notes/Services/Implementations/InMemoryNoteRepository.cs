using Notes.Models;
using Notes.Services.Interfaces;

namespace Notes.Services.Implementations;

public class InMemoryNoteRepository : INoteRepository
{
    private readonly List<Note> _notes = new List<Note>();

    public IEnumerable<Note> GetAllNotes() => _notes;
    public Note GetNoteById(int id) => _notes.FirstOrDefault(n => n.Id == id);
    public void AddNote(Note note) => _notes.Add(note);
    public void UpdateNote(Note note)
    {
        var existingNote = GetNoteById(note.Id);
        if (existingNote != null)
        {
            existingNote.Title = note.Title;
            existingNote.Content = note.Content;
        }
    }
    public void DeleteNoteById(int id) => _notes.Remove(GetNoteById(id));
}