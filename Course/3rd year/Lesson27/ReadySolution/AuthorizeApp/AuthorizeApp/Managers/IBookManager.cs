using AuthorizeApp.Models;

namespace AuthorizeApp.Managers;

public interface IBookManager
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(int id, Book updatedBook);
    Task<bool> DeleteBookAsync(int id);
    Task<Book?> MarkAsReadAsync(int id);
}