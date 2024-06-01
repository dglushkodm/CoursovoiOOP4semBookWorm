using System.Windows;

using CursOOP.Views;

namespace CursOOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources.Add("MainFrame", this.frame);
            frame.Navigate(new Login());
            Application.Current.Resources.Add("Language", "Ru");
            Application.Current.Resources.Add("Appearance", "Dark");

        }
    }
}