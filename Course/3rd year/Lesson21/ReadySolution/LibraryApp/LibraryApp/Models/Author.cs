namespace LibraryApp.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public IEnumerable<Book> Books { get; set; }
}