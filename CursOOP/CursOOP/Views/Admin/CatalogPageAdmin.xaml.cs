using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.ViewModels.Admin;
using CursOOP.Views.Admin;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.Views.User;

public partial class CatalogPageAdmin : Page
{
   
    public CatalogPageAdmin()
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
        
        var vm = DataContext as CatalogAdminViewModel;
        vm.Search(Search.Text);
    }

   
}