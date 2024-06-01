using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models;

public class Review: Base
{
    [ForeignKey("UserId")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("BookId")]
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    
    public string ReviewText { get; set; }
    public string UserName { get; set; }
    public byte[] ProfileImage { get; set; }
}