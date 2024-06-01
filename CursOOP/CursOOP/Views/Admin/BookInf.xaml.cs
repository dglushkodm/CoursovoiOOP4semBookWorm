using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.Views.Admin;

public partial class BookInf : Page
{
    public BookInf()
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
    
   
    public BookInf(Guid id)
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
        DataContext = new BookInfViewModel(id);
    }

    
}