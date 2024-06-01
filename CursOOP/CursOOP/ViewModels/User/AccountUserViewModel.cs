using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.Win32;

namespace CursOOP.ViewModels.User;

public class AccountUserViewModel:INotifyPropertyChanged
{
    
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private EntityFramework.Models.User _user;
    private UnitOfWork _unitOfWork;
    private Guid Id;
    private List<Book> _books;
    
    public List<Book> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }
    }
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    private string _email;
    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    
    private double _nam;
    public double Nam
    {
        get => _nam;
        set
        {
            _nam = value;
            OnPropertyChanged(nameof(Nam));
        }
    }
    
    private List<UserBook> _likedbooks;
    public List<UserBook> LikedBooks
    {
        get => _likedbooks;
        set
        {
            _likedbooks = value;
            OnPropertyChanged(nameof(LikedBooks));
        }
    }
    private List<Book> _likedbooksinit;
    public List<Book> LikedBooksInit
    {
        get => _likedbooksinit;
        set
        {
            _likedbooksinit = value;
            OnPropertyChanged(nameof(LikedBooksInit));
        }
    }
    private byte[] _img;
    public byte[] Img
    {
        get => _img;
        set
        {
            _img = value;
            OnPropertyChanged(nameof(Img));
        }
    }
    
    private DelegateCommand _imgCommand;

    public ICommand ImgCommand
    {
        get
        {
            if (_imgCommand == null)
                _imgCommand = new DelegateCommand(ChooseImg);
            return _imgCommand;
        }
    }
    
    private void ChooseImg()
    {
        OpenFileDialog openDialog = new OpenFileDialog();
        openDialog.Filter = "Image files|* bmp;*.jpg;*png";
        openDialog.FilterIndex = 1;
        if (openDialog.ShowDialog() == true)
        {
            using (FileStream fs = new FileStream(openDialog.FileName, FileMode.Open))
            {
                byte[] imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
                Img = imageData;
                EntityFramework.Models.User user = new EntityFramework.Models.User()
                {
                    Email = _user.Email, Password = _user.Password, Id = _user.Id, ProfileImage = Img,
                    Role = _user.Role, Username = _user.Username
                };
                _unitOfWork.Users.Update(_user,user);
                Application.Current.Resources["User"] = user;
            }
        }

    }
    
    public AccountUserViewModel()
    {
        
        _unitOfWork = new UnitOfWork();
        Books = _unitOfWork.Books.Read();
        _user = (EntityFramework.Models.User)Application.Current.Resources["User"];
        LikedBooks = _unitOfWork.UserBooks.Read().FindAll(b => b.UserId == _user.Id);
        LikedBooksInit = new List<Book>();
        foreach (UserBook ub in LikedBooks)
        {
            LikedBooksInit.Add(Books.Find(b => b.Id == ub.BookId));
        }
        EntityFramework.Models.User user = _unitOfWork.Users.Read().Find(u => u.Id == _user.Id);
        Name = _user.Username;
        Email = _user.Email;
        Img = user.ProfileImage;
    }
}