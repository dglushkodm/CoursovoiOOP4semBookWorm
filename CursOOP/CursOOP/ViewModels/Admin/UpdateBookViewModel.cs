using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.Win32;

namespace CursOOP.ViewModels.Admin;

public class UpdateBookViewModel:INotifyPropertyChanged
{
    private UnitOfWork _unitOfWork;
    private Book _oldBook;
    
    public UpdateBookViewModel(Guid id)
    {
        _unitOfWork = new UnitOfWork();
        _oldBook = _unitOfWork.Books.Read().Find(b => b.Id.Equals(id));
        Name = _oldBook.Name;
        Shortdesc = _oldBook.Shortdesc;
        Fulldesc = _oldBook.Fulldesc;
        Img = _oldBook.Img;
        Imgback = _oldBook.ImgBack;
        Author = _oldBook.Author;
        Year = _oldBook.Year.ToString();
        SelectedItem = _oldBook.Status;
    }
       
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private DelegateCommand _createCommand;

    public ICommand AddCommand
    {
        get
        {
            if (_createCommand == null)
                _createCommand = new DelegateCommand(RegisterRedirect);
            return _createCommand;
        }
    }
    private string _message;
    public string Message { get { return _message; }
        set { _message = value;
            OnPropertyChanged(nameof(Message));
        } }
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
            else
            {
                var book = new Book()
                {
                    Id = _oldBook.Id, Name = Name, Img = Img, Fulldesc = Fulldesc, ImgBack = Imgback, Author = Author,
                    Year = int.Parse(Year), Shortdesc = Shortdesc, Rate = _oldBook.Rate, Status = SelectedItem
                };
                _unitOfWork.Books.Update(_oldBook, book);
                var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
                mainFrame.Navigate(new CatalogPageAdmin());
            }
        }
        catch{}
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
    public UpdateBookViewModel(){}
}