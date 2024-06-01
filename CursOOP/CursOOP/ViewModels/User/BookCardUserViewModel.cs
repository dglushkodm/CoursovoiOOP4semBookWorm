using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.ViewModels.User;

public class BookCardUserViewModel:INotifyPropertyChanged
{
    
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public void Like(Book book)
    {
        try
        {
            var _user = (EntityFramework.Models.User)Application.Current.Resources["User"];
            var Liked = new UserBook() { Id = new Guid(), BookId = book.Id, UserId = _user.Id };
            if (_unitOfWork.UserBooks.Read().Any(b => b.BookId == book.Id))
            {
                var boook = _unitOfWork.UserBooks.Read().FirstOrDefault(b => b.BookId == book.Id);
                _unitOfWork.UserBooks.Delete(boook);
            }
            else
            {
                _unitOfWork.UserBooks.Create(Liked);
            }
        }
        catch{}
    }
    
    private UnitOfWork _unitOfWork; 
    public BookCardUserViewModel()
    {
        _unitOfWork = new UnitOfWork();
        
    }
    
}