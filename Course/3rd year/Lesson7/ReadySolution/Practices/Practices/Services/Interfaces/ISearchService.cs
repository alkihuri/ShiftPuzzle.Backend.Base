using Practices.Models;

namespace Practices.Services.Interfaces;

public interface ISearchService
{
    List<Book> SearchBooks(string query);
    List<User> SearchUsers(string query);
}