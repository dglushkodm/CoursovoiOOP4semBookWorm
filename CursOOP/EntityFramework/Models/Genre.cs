using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Models;

public class Genre : Base
{
   
    public string NameGenre { get; set; }

    public List<Book> Books { get; set; }

}