using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.Win32;

namespace CursOOP.ViewModels.Admin;

public class AddBookViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private string _message;
    public string Message { get { return _message; }
        set { _message = value;
            OnPropertyChanged(nameof(Message));
        } }
  
    private ICommand _createCommand;

    public ICommand AddCommand
    {
        get
        {
            if (_createCommand == null)
                _createCommand = new DelegateCommand(RegisterRedirect);
            return _createCommand;
        }
    }

    private void RegisterRedirect()
    {
        try
        {
            if (Name == String.Empty || Author == String.Empty || Fulldesc == String.Empty ||
                Shortdesc == String.Empty ||
                Img == null || Imgback == null || !int.TryParse(Year, out int value))
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Все поля должны быть заполнены");
            }
            else if (!int.TryParse(Year, out int valuee) || valuee < 1990 || valuee > 2024)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Неккоректный год");
            }
            else if(Name.Length < 30)
            {
                var book = new Book
                {
                    Name = _name, Author = _author, Fulldesc = _fulldesc, Shortdesc = _shortdesc,
                    Year = int.Parse(_year),
                    Img = _img, ImgBack = _imgback, Status = SelectedItem
                };
                _unitOfWork.Books.Create(book);



                var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
                mainFrame.Navigate(new CatalogPageAdmin());
            }
        }
        catch{}
    }
    
    Frame mainFrame = Application.Current.Resources["MainFrame"] as Frame;
    Frame frame = Application.Current.Resources["HomePageFrame"] as Frame;
    private DelegateCommand _undoCommand;
    public ICommand UndoCommand
    {
        get
        {
            if (_undoCommand == null)
                _undoCommand = new DelegateCommand(Udno);
            return _undoCommand;
        }
    }

    private void Udno()
    {
        if (mainFrame.CanGoBack)
        {
            mainFrame.GoBack();
        }

        if (frame.CanGoBack)
        {
            frame.GoBack();
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
            }
        }

    }
    private DelegateCommand _imgBackCommand;

    public ICommand ImgBackCommand
    {
        get
        {
            if (_imgBackCommand == null)
                _imgBackCommand = new DelegateCommand(ChooseImgBack);
            return _imgBackCommand;
        }
    }
    
    private void ChooseImgBack()
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
                Imgback = imageData;
            }
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

    private string _selectedItem;
    public string SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
           
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
    
    private string _year;
    public string Year
    {
        get => _year;
        set
        {
            _year = value;
            OnPropertyChanged(nameof(Year));
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

    
    private UnitOfWork _unitOfWork; 
    public AddBookViewModel()
    {
        _unitOfWork = new UnitOfWork();
        /*List<string> list = new List<string>
        {
            "Фантастика",
            "Фэнтези",
            "Драма",
            "Комедия",
            "Приключения",
            "Романтика",
            "Школа",
            "Экшн",
            "Психологическое"
        };
        foreach (var genre in list)
        {
            Genre ger = new Genre(){NameGenre = genre};
            _unitOfWork.Genres.Create(ger);
        }*/
       
    }
}