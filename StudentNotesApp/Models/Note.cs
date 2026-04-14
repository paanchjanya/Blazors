using System.ComponentModel.DataAnnotations;

namespace StudentNotesApp.Models;


public class Note
{
    public int Id {get; set;}

    [Required(ErrorMessage ="Title is required")]
    [StringLength(100, ErrorMessage ="Max 100 characters")]
    public string Title {get; set;} = string.Empty;

    [Required(ErrorMessage ="Content is required")]
    public string Content {get; set;} = string.Empty;
    public DateTime Created {get; set;} = DateTime.UtcNow;
}