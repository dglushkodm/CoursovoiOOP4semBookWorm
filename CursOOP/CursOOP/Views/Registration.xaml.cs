using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels;

namespace CursOOP.Views
{
    public partial class Registration : Page
    {
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is RegistrationViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
        public Registration()
        {
            InitializeComponent();
        }
    }
}