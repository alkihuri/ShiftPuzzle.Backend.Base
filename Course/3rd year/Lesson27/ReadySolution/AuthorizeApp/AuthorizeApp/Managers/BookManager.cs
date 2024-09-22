using AuthorizeApp.Data;
using AuthorizeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizeApp.Managers;

public class BookManager : IBookManager
{
    private readonly ApplicationDbContext _context;

    public BookManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book?> UpdateBookAsync(int id, Book updatedBook)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return null; // Книга не найдена
        }

        // Обновляем данные книги
        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        book.Description = updatedBook.Description;
        book.IsRead = updatedBook.IsRead;

        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return false; // Книга не найдена
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Book?> MarkAsReadAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return null; // Книга не найдена
        }

        book.IsRead = true;
        await _context.SaveChangesAsync();
        return book;
    }
}