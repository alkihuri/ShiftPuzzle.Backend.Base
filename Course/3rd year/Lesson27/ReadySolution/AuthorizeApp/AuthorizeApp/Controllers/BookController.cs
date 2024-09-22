using AuthorizeApp.Managers;
using AuthorizeApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizeApp.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookManager _bookManager;

    public BookController(BookManager bookManager)
    {
        _bookManager = bookManager;
    }

    // Получение всех книг
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookManager.GetAllBooksAsync();
        return Ok(books);
    }

    // Получение книги по ID
    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookManager.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    // Добавление новой книги
    [HttpPost]
    [Authorize(Roles = "Librarian")]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdBook = await _bookManager.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    // Обновление данных книги
    [HttpPut("{id}")]
    [Authorize(Roles = "Librarian")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
    {
        if (id != updatedBook.Id)
        {
            return BadRequest("ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var book = await _bookManager.UpdateBookAsync(id, updatedBook);
        if (book == null)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Удаление книги
    [HttpDelete("{id}")]
    [Authorize(Roles = "Librarian")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookManager.DeleteBookAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    // Отметка книги как прочитанной
    [HttpPatch("{id}/mark-as-read")]
    [Authorize(Roles = "User, Librarian")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        var book = await _bookManager.MarkAsReadAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }
}

