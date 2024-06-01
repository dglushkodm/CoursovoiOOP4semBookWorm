using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using CursOOP.Views.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.Views.Admin;

public partial class BookCardAdmin : UserControl
{
    public BookCardAdmin()
    {
        InitializeComponent();
    }
    
   
    private void Delete_click(object sender, RoutedEventArgs e)
    {
        var unit = new UnitOfWork();
        if (DataContext != null)
        {
            var book = DataContext as Book;
            unit.Books.Delete(book);
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new CatalogPageAdmin());
        }
      
    }
    
    private void Edit_click(object sender, RoutedEventArgs e)
    {
        var unit = new UnitOfWork();
        if (DataContext != null)
        {
            var book = DataContext as Book;
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new UpdateBook(book.Id));
        }
      
    }

    private void BookPanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var unit = new UnitOfWork();
        if (DataContext != null)
        {
            var book = DataContext as Book;
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new BookInf(book.Id));
        }
    }
}