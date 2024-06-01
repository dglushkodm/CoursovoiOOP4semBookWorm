using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views.Admin;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.IdentityModel.Tokens;

namespace CursOOP.ViewModels.User;

public class CatalogUserViewModel:INotifyPropertyChanged
{
    
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private UnitOfWork _unitOfWork { get; set; }
    private List<Book> _books;
    private List<Book> _booksInit;
    
    public List<Book> Books
    {
        get => _books;
        set
        {
            _books = value;
            OnPropertyChanged(nameof(Books));
        }
    }


    private string _search;
    public string SearchStr
    {
        get => _search;
        set
        {
            _search = value;
            
            OnPropertyChanged(nameof(SearchStr));
        }
    }

    private DelegateCommand _filterCommand;
    public ICommand FilterCommand
    {
        get
        {
            if (_filterCommand == null)
                _filterCommand = new DelegateCommand(FilterCards);
            return _filterCommand;
        }
    }      
    public string Min { get; set; }
    public string Max { get; set; }
        
    public string MinRate { get; set; }
    public string MaxRate { get; set; }
    
    private bool isSelectedEnd;

    public bool IsSelectedEnd
    {
        get { return isSelectedEnd; }
        set
        {
            if (isSelectedEnd != value)
            {
                isSelectedEnd = value;
                OnPropertyChanged(nameof(IsSelectedEnd));
            }
        }
    }
    
    private bool isSelectedOng;

    public bool IsSelectedOng
    {
        get { return isSelectedOng; }
        set
        {
            if (isSelectedOng != value)
            {
                isSelectedOng = value;
                OnPropertyChanged(nameof(IsSelectedOng));
            }
        }
    }
    private string _message;
    public string Message { get { return _message; }
        set { _message = value;
            OnPropertyChanged(nameof(Message));
        } }
    private bool isSelectedZab;

    public bool IsSelectedZab
    {
        get { return isSelectedZab; }
        set
        {
            if (isSelectedZab != value)
            {
                isSelectedZab = value;
                OnPropertyChanged(nameof(IsSelectedZab));
            }
        }
    }
    public void FilterCards()
    {
        try
        {
            string end = "";
            string ong = "";
            string zab = "";

            if (Min != null && Max != null && MinRate == null && MaxRate == null)
            {
                if (!int.TryParse(Min, out int value) || value < 1990 || value > 2024)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                        Message = "Год не может быть раньше 1990 или являться строкой");
                }
                else if (!int.TryParse(Max, out int valuee) || valuee < 1990 || valuee > 2024)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                        Message = "Год не может быть позже 2024 или являться строкой");
                }
                else
                {
                    Books = Books.FindAll(b =>
                        b.Year >= int.Parse(Min) && b.Year <= int.Parse(Max));

                    if (IsSelectedEnd)
                    {
                        end = "Завершён";
                        Books = Books.FindAll(b =>
                            b.Status == end);
                    }

                    if (IsSelectedOng)
                    {
                        ong = "Онгоинг";
                        Books = Books.FindAll(b =>
                            b.Status == ong);
                    }

                    if (IsSelectedZab)
                    {
                        zab = "Заброшен";
                        Books = Books.FindAll(b =>
                            b.Status == zab);
                    }
                }
            }

            else if (Min == null && Max == null && MinRate != null && MaxRate != null)
            {
                if (!int.TryParse(MinRate, out int valueee) || valueee < 1 || valueee > 9)
                {
                    Application.Current.Dispatcher.Invoke(() => Message = "Минимальная оценка должна быть от 1 до 9");
                }
                else if (!int.TryParse(MaxRate, out int valueeee) || valueeee < 2 || valueeee > 10)
                {
                    Application.Current.Dispatcher.Invoke(() => Message = "Максимальная оценка должна быть от 2 до 10");
                }
                else
                {
                    Books = Books.FindAll(b =>
                        b.Rate >= int.Parse(MinRate) && b.Rate <= int.Parse(MaxRate));
                    /* _booksStatus = Books.FindAll(b =>
                         b.Status == end || b.Status == ong || b.Status == zab);
                     if(_booksStatus != null){
                         foreach (var booksStatu in _booksStatus)
                         {
                             Books.Add(booksStatu);
                         }
                     }*/
                    if (IsSelectedEnd)
                    {
                        end = "Завершён";
                        Books = Books.FindAll(b =>
                            b.Status == end);
                    }

                    if (IsSelectedOng)
                    {
                        ong = "Онгоинг";
                        Books = Books.FindAll(b =>
                            b.Status == ong);
                    }

                    if (IsSelectedZab)
                    {
                        zab = "Заброшен";
                        Books = Books.FindAll(b =>
                            b.Status == zab);
                    }
                }
            }
            else if (Min != null && Max != null && MinRate != null && MaxRate != null)
            {

                Books = Books.FindAll(b =>
                    b.Year >= int.Parse(Min) && b.Year <= int.Parse(Max) && b.Rate >= int.Parse(MinRate) &&
                    b.Rate <= int.Parse(MaxRate));
                if (IsSelectedEnd)
                {
                    end = "Завершён";
                    Books = Books.FindAll(b =>
                        b.Status == end);
                }

                if (IsSelectedOng)
                {
                    ong = "Онгоинг";
                    Books = Books.FindAll(b =>
                        b.Status == ong);
                }

                if (IsSelectedZab)
                {
                    zab = "Заброшен";
                    Books = Books.FindAll(b =>
                        b.Status == zab);
                }
            }
            else
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Правильно заполните поля");
            }
        }
        catch{}
    }
    private DelegateCommand _sortByYearCommand;
    public ICommand SortByYearCommand
    {
        get
        {
            if (_sortByYearCommand == null)
                _sortByYearCommand = new DelegateCommand(SortByYear);
            return _sortByYearCommand;
        }
    }
    private bool _isDesc = false;
    private void SortByYear()
    {
        try
        {
            if (!_isDesc)
            {
                var books = from b in Books orderby b.Year descending select b;
                Books = books.ToList();
                _isDesc = true;
            }
            else
            {
                var books = from b in Books orderby b.Year select b;
                Books = books.ToList();
                _isDesc = false;
            }
        }
        catch{}
    }

    private DelegateCommand _filterDeleteCommand;
    public ICommand DeleteFilter
    {
        get
        {
            if (_filterDeleteCommand == null)
                _filterDeleteCommand = new DelegateCommand(Deletee);
            return _filterDeleteCommand;
        }
    }      

    public void Deletee()
    {
        Books = _booksInit;
        Message = "";
    }
    
    public void Search(string str)
    {
        try
        {
            if (!str.IsNullOrEmpty())
            {
                Books = Books.Where(b => b.Name.ToLower().Contains(str.ToLower())).ToList();
            }
            else
            {
                Books = _booksInit;
            }
        }
        catch{}
    }
    
    
    
    public CatalogUserViewModel()
    {
        _unitOfWork = new UnitOfWork();
        Books = _unitOfWork.Books.Read();
        _booksInit = Books;
    }
}