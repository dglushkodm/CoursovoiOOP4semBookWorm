using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.ViewModels;

public class RatingViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private List<bool> _ratings;
    public List<bool> Ratings
    {
        get => _ratings;
        set
        {
            _ratings = value;
            OnPropertyChanged(nameof(Ratings));
        }
    }

    private int _selectedRating;
    public int SelectedRating
    {
        get => _selectedRating;
        set
        {
            _selectedRating = value;
            OnPropertyChanged(nameof(SelectedRating));
        }
    }

    public ICommand RateCommand { get; private set; }
    public ICommand SubmitCommand { get; private set; }
    public RatingViewModel()
    {
        
    }

    private UnitOfWork _unitOfWork;
    private Book _book;
    private EntityFramework.Models.User _user;
    public RatingViewModel(Book book)
    {
        _user = (EntityFramework.Models.User)Application.Current.Resources["User"];
        _unitOfWork = new UnitOfWork();
        InitializeRatings();
        RateCommand = new DelegateCommand<object>(Rate);
        SubmitCommand = new DelegateCommand(Submit);
        _book = book;
    }

    private void InitializeRatings()
    {
        Ratings = new List<bool>(10);
        for (int i = 0; i < 10; i++)
        {
            Ratings.Add(false);
        }
    }

    private void Rate(object rate)
    {
            SelectedRating = Convert.ToInt32(rate);
    }
   
    private void Submit()
    {
        try
        {
            var RB = new BookRate() { BookId = _book.Id, UserId = _user.Id, Rate = SelectedRating };
            if (_unitOfWork.BookRates.Read().Any(b => b.UserId == _user.Id && b.BookId == _book.Id))
            {
                var raate = _unitOfWork.BookRates.Read()
                    .FirstOrDefault(b => b.UserId == _user.Id && b.BookId == _book.Id);
                _unitOfWork.BookRates.Delete(raate);
                _unitOfWork.BookRates.Create(RB);
            }
            else
            {
                _unitOfWork.BookRates.Create(RB);
            }

            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            if (_user.Role == ROLES.CLIENT)
                mainFrame.Navigate(new BookInfUser(_book.Id));
            else
                mainFrame.Navigate(new BookInf(_book.Id));
        }
        catch{}
    }
}
