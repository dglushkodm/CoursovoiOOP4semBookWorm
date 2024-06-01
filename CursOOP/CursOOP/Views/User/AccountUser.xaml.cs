using System.Windows;
using System.Windows.Controls;

namespace CursOOP.Views.User;

public partial class AccountUser : Page
{
    public AccountUser()
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
}