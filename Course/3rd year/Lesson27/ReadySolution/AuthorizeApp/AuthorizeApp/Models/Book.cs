using System.ComponentModel.DataAnnotations;

namespace AuthorizeApp.Models;

public class Book
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; }

    [Required]
    [StringLength(100)]
    public string Author { get; set; }

    public string Description { get; set; }

    public bool IsRead { get; set; } = false;
}