using System.Windows;
using CursOOP.ViewModels;
using EntityFramework.Models;

namespace CursOOP.Views;

public partial class Rating : Window
{
    public Rating()
    {
        InitializeComponent();
    }
    
    public Rating(Book book)
    {
        InitializeComponent();
        DataContext = new RatingViewModel(book);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}