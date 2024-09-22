namespace LibraryApp.Models;

public class Reader
{
    public int ReaderId { get; set; }
    public string Name { get; set; }
    public IEnumerable<Book> BorrowedBooks { get; set; }
}