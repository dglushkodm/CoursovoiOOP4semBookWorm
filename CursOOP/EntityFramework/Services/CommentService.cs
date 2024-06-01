using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services;

public class CommentService//: ICommentService
{
    private CursOOPDbContext db;

    public CommentService(CursOOPDbContext db)
    {
        this.db = db;
    }
    
    /*public List<Comment> GetByBookId(Guid bookId)
    {
       // var data = db.Comments.Include(c=> c.User ).ToList();
       // return data.Where(c => c.BookId == bookId).ToList();
    }*/

    /*public Comment Create(Comment comment)
    {
        //var awcomment = db.Comments.Add(comment);
        db.SaveChanges();
        //return awcomment.Entity;
    }*/
}