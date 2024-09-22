using Practices.Models;
using Practices.Services.Interfaces;

namespace Practices.Services.Implementations;

public class SearchService : ISearchService
{
    private readonly IBookService _bookService;
    private readonly IUserService _userService;

    public SearchService(IBookService bookService, IUserService userService)
    {
        _bookService = bookService;
        _userService = userService;
    }

    public List<Book> SearchBooks(string query)
    {
        return _bookService.GetBooks().Where(b => b.Title.Contains(query) || b.Author.Contains(query)).ToList();
    }

    public List<User> SearchUsers(string query)
    {
        return _userService.GetUsers().Where(u => u.Username.Contains(query) || u.Email.Contains(query)).ToList();
    }
}