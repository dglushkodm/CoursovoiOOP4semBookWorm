using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.Admin;
using EntityFramework;
using EntityFramework.Models;
using Application = System.Windows.Application;

namespace CursOOP.ViewModels.Admin;

public class BookInfViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private UnitOfWork _unitOfWork;
    private Book _book;
    public BookInfViewModel(){}
    public BookInfViewModel(Guid id)
    {
        
        _unitOfWork = new UnitOfWork();
        Reviews = _unitOfWork.Reviews.Read().FindAll(r=> r.BookId == id);
        Chapters = _unitOfWork.Chapters.Read().FindAll(c => c.BookId == id);
        _book = _unitOfWork.Books.Read().Find(b => b.Id.Equals(id));
        Id = id;
        Name = _book.Name;
        Shortdesc = _book.Shortdesc;
        Fulldesc = _book.Fulldesc;
        Img = _book.Img;
        Imgback = _book.ImgBack;
        Year = _book.Year;
        Author = _book.Author;
        Status = _book.Status;
        List<BookRate> ratee = _unitOfWork.BookRates.Read().FindAll(c => c.BookId == id).ToList();
        int rr = 0;
        int count = 0;
        foreach (var r in ratee)
        {
            rr = rr + r.Rate;
            count++;
        }

        if (count == 0)
        {
            Rate = 0;
        }
        else
        {
            Rate = rr / count;
        }

        var BOOK = new Book{Id = Id,Name = Name,Author = Author,Fulldesc = Fulldesc,Shortdesc = Shortdesc,Year = Year, Img = Img,ImgBack = Imgback, Status = Status, Rate = Rate};
        _unitOfWork.Books.Update(_book,BOOK);
    }
    private EntityFramework.Models.User _user = (EntityFramework.Models.User)Application.Current.Resources["User"];
    private List<Review> _reviews;
    
    public List<Review> Reviews
    {
        get => _reviews;
        set
        {
            _reviews = value;
            OnPropertyChanged(nameof(Reviews));
        }
    }
    private List<Chapter> _chapters;
    
    public List<Chapter> Chapters
    {
        get => _chapters;
        set
        {
            _chapters = value;
            OnPropertyChanged(nameof(Chapters));
        }
    }
    private Guid _id;
    public Guid Id
    {
        get => _id;
        set
        {
            _id= value;
            OnPropertyChanged(nameof(Id));
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
    
    private double _rate;
    public double Rate
    {
        get => _rate;
        set
        {
            _rate = value;
            OnPropertyChanged(nameof(Rate));
        }
    }
    
    private string _status;
    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }
    private string _shortdesc;
    public string Shortdesc
    {
        get => _shortdesc;
        set
        {
            _shortdesc = value;
            OnPropertyChanged(nameof(Shortdesc));
        }
    }

    private string _author;
    public string Author
    {
        get => _author;
        set
        {
            _author = value;
            OnPropertyChanged(nameof(Author));
        }
    }

    private string _fulldesc;
    public string Fulldesc
    {
        get => _fulldesc;
        set
        {
            _fulldesc = value;
            OnPropertyChanged(nameof(Fulldesc));
        }
    }
    private string _review;
    public string Review
    {
        get => _review;
        set
        {
            _review = value;
            OnPropertyChanged(nameof(Review));
        }
    }
    private int _year;
    public int Year
    {
        get => _year;
        set
        {
            _year = value;
            OnPropertyChanged(nameof(Year));
        }
    }
    
    private DelegateCommand _ratingCommand;
    public ICommand RatingCommand
    {
        get
        {
            if (_ratingCommand == null)
                _ratingCommand = new DelegateCommand(Rating);
            return _ratingCommand;
        }
    }      
  
    public void Rating()
    {
        
        Rating ratingWindow = new Rating(_book);
        ratingWindow.ShowDialog(); 
    }

    
    private DelegateCommand _addChapter;
    public ICommand AddCommand
    {
        get
        {
            if (_addChapter == null)
                _addChapter = new DelegateCommand(Add);
            return _addChapter;
        }
    }      
  
    public void Add()
    {
        
        var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
        mainFrame.Navigate(new AddChapter(_book.Id));
    }
    
    private DelegateCommand<Review> _delRev;
    public ICommand DeleteReview
    {
        get
        {
            if (_delRev == null)
                _delRev = new DelegateCommand<Review>(Delete);
            return _delRev;
        }
    }      
  
    public void Delete(Review rev)
    {

        try
        {
            _unitOfWork.Reviews.Delete(rev);
            Reviews = _unitOfWork.Reviews.Read().FindAll(r=> r.BookId == Id);
        }
        catch{}
    }
    
    private DelegateCommand<Chapter> _read;
    public ICommand ReadCommand
    {
        get
        {
            if (_read == null)
                _read = new DelegateCommand<Chapter>(Read);
            return _read;
        }
    }      
  
    public void Read(Chapter chapt)
    {
        var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
        mainFrame.Navigate(new ReadBook(chapt));
    }
    
    private DelegateCommand _addCommentCommand;
    public ICommand AddCommentCommand
    {
        get
        {
            if (_addCommentCommand == null)
                _addCommentCommand = new DelegateCommand(AddComment);
            return _addCommentCommand;
        }
    }      
  
    public void AddComment()
    {
        try
        {
            var com = new Review()
            {
                Id = new Guid(), BookId = _book.Id, ReviewText = Review, UserId = _user.Id, UserName = _user.Username,
                ProfileImage = _user.ProfileImage
            };
            _unitOfWork.Reviews.Create(com);
            Reviews = _unitOfWork.Reviews.Read().FindAll(r => r.BookId == Id);
            Review = String.Empty;
        }
        catch{}
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
    
    private byte[] _imgback;
    public byte[] Imgback
    {
        get => _imgback;
        set
        {
            _imgback = value;
            OnPropertyChanged(nameof(Imgback));
        }
    }
}