using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels;
using EntityFramework.Models;

namespace CursOOP.Views;

public partial class ReadBook : Page
{
    public ReadBook()
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
    private void ScrollToBottom_Click(object sender, RoutedEventArgs e)
    {
        scrollViewer.ScrollToBottom();
    }
    private void ScrollToTop_Click(object sender, RoutedEventArgs e)
    {
        scrollViewer.ScrollToTop();
    }
    public ReadBook(Chapter chapt)
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

        DataContext = new ReadBookViewModel(chapt);
    }
}