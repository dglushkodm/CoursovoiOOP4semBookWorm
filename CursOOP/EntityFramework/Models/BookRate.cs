using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models;

public class BookRate : Base
{
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("BookId")]
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    
    public int Rate { get; set; }
}