namespace EntityFramework.Models;

public class Comment: Base
{
    public User User { get; set; }
    public Guid BookId { get; set; }
    public string Review { get; set; }
}