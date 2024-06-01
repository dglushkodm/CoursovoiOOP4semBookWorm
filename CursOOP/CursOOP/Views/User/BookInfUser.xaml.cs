using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels.Admin;
using CursOOP.ViewModels.User;
using EntityFramework;

namespace CursOOP.Views.User;

public partial class BookInfUser : Page
{
    public BookInfUser()
    {
        InitializeComponent();
        if (Application.Current.Resources.Contains("HomePageFrame"))
        {
            Application.Current.Resources["HomePageFrame"] = this.HeaderFrame;
        }
        else
        {
            Application.Current.Resources.Add("HomePageFrame", this.HeaderFrame);
        }
        HeaderFrame.Navigate(new Header());
    }
    
    public BookInfUser(Guid id)
    {
        InitializeComponent();
       
        if (Application.Current.Resources.Contains("HomePageFrame"))
        {
            Application.Current.Resources["HomePageFrame"] = this.HeaderFrame;
        }
        else
        {
            Application.Current.Resources.Add("HomePageFrame", this.HeaderFrame);
        }
        HeaderFrame.Navigate(new Header());
        DataContext = new BookInfUserViewModel(id);
    }
}