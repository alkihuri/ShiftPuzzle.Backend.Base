using Practices.Models;
using Practices.Services.Interfaces;

namespace Practices.Services.Implementations;

public class BookService : IBookService
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void EditBook(Book book)
    {
        var existingBook = GetBook(book.BookId);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.PublishedYear = book.PublishedYear;
        }
    }

    public void DeleteBook(int bookId)
    {
        var book = GetBook(bookId);
        if (book != null)
        {
            books.Remove(book);
        }
    }

    public Book GetBook(int bookId)
    {
        return books.FirstOrDefault(b => b.BookId == bookId);
    }
    
    public IEnumerable<Book> GetBooks()
    {
        return books;
    }
}