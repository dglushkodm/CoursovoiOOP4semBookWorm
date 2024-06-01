using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.ViewModels.User;
using CursOOP.Views.Admin;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace CursOOP.Views.User;

public partial class BookCardUser : UserControl
{
    public BookCardUser()
    {
        InitializeComponent();
        
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
    
    private void Like_Click(object sender, RoutedEventArgs e)
    {
        var unit = new UnitOfWork();
        if (DataContext != null)
        {
            var book = DataContext as Book;
            
            BookCardUserViewModel vm = new BookCardUserViewModel();
            vm?.Like(book);
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