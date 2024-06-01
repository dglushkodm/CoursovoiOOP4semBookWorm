using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels.User;

namespace CursOOP.Views.User;

public partial class CatalogPageUser : Page
{
    public CatalogPageUser()
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
    
    private void Search_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        
        var vm = DataContext as CatalogUserViewModel;
        vm.Search(Search.Text);
    }
}