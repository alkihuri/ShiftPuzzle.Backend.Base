using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services.Interfaces;

namespace Notes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteRepository _noteRepository;
    private readonly ILoggerService _logger;

    public NotesController(INoteRepository noteRepository, ILoggerService logger)
    {
        _noteRepository = noteRepository;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllNotes()
    {
        var notes = _noteRepository.GetAllNotes();
        _logger.Log("Retrieved all notes");
        return Ok(notes);
    }

    [HttpGet("{id}")]
    public IActionResult GetNoteById(int id)
    {
        var note = _noteRepository.GetNoteById(id);
        if (note == null)
        {
            return NotFound();
        }
        _logger.Log($"Retrieved note with ID {id}");
        return Ok(note);
    }

    [HttpPost]
    public IActionResult CreateNote([FromBody] Note note)
    {
        if (note == null)
        {
            return BadRequest();
        }
        _noteRepository.AddNote(note);
        _logger.Log($"Created note with ID {note.Id}");
        return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateNote(int id, [FromBody] Note updatedNote)
    {
        if (updatedNote == null || id != updatedNote.Id)
        {
            return BadRequest();
        }
        var existingNote = _noteRepository.GetNoteById(id);
        if (existingNote == null)
        {
            return NotFound();
        }
        _noteRepository.UpdateNote(updatedNote);
        _logger.Log($"Updated note with ID {id}");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNoteById(int id)
    {
        var existingNote = _noteRepository.GetNoteById(id);
        if (existingNote == null)
        {
            return NotFound();
        }
        _noteRepository.DeleteNoteById(id);
        _logger.Log($"Deleted note with ID {id}");
        return NoContent();
    }
}
