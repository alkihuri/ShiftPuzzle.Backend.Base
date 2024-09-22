using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;
using Notes.Services.Interfaces;

namespace Notes.Services.Implementations;

public class SqliteNoteRepository(DataContext dataContext) : INoteRepository
{
    public IEnumerable<Note> GetAllNotes()
    {
        return dataContext.Notes.ToList();
    }
    public Note GetNoteById(int id)
    {
        return dataContext.Notes.FirstOrDefault(n => n.Id == id);
    }
    public void AddNote(Note note)
    {
        dataContext.Notes.Add(note);
        dataContext.SaveChanges();
    }
    public void UpdateNote(Note note)
    {
        var existingNote = dataContext.Notes.FirstOrDefaultAsync(c => c.Id == note.Id);
        
        if (existingNote != null)
        {
            dataContext.Notes.Update(note);
            dataContext.SaveChanges();
        }
    }

    public void DeleteNoteById(int id)
    {
        var existingNote = dataContext.Notes.FirstOrDefault(c => c.Id == id);
        
        if (existingNote != null)
        {
            dataContext.Notes.Remove(existingNote);
            dataContext.SaveChanges();
        }
    }
}