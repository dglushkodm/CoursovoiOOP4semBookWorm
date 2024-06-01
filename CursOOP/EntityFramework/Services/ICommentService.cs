using EntityFramework.Models;

namespace EntityFramework.Services;

public interface ICommentService
{
   List<Comment> GetByBookId(Guid bookId);

   public Comment Create(Comment comment);
}