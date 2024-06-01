using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels;

namespace CursOOP.Views
{
    public partial class Login : Page
    {
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
        public Login()
        {
            InitializeComponent();
        }
    }
}