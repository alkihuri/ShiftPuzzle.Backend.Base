using Practices.Models;

namespace Practices.Services.Interfaces;

public interface IBookService
{
    public void AddBook(Book book);
    public void EditBook(Book book);
    public void DeleteBook(int bookId);
    public Book GetBook(int bookId);
    public IEnumerable<Book> GetBooks();
}