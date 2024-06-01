using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;
using Prism.Commands;

namespace CursOOP.ViewModels
{
    public class RegistrationViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private string _username;
        public string Username { get { return _username; } 
            set { _username = value;
                OnPropertyChanged(nameof(Username));
            } }

        private string _email;
        public string Email { get { return _email; } 
            set { _email = value;
                OnPropertyChanged(nameof(Email));
            } }

        
        private string _password;
        public string Password { get { return _password; } 
            set { _password = value;
                OnPropertyChanged(nameof(Password));
            } }


        private string _message;
        public string Message { get { return _message; }
            set { _message = value;
                OnPropertyChanged(nameof(Message));
            } }
        
        
        
        private DelegateCommand _enterRedirectCommand;
        public ICommand EnterRedirectCommand
        {
            get
            {
                if (_enterRedirectCommand == null)
                    _enterRedirectCommand = new DelegateCommand(EnterRedirect);
                return _enterRedirectCommand;
            }
        }
        private UnitOfWork _unitOfWork;

        public RegistrationViewModel()
        {
            _unitOfWork = new UnitOfWork();
        }
        private void EnterRedirect()
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
                EntityFramework.Models.User user = new EntityFramework.Models.User(_username, _email, hashedPassword);
                bool isUsernameTaken = _unitOfWork.Users.Read().Any(u => u.Username == Username);
                if (isUsernameTaken)
                {
                    Application.Current.Dispatcher.Invoke(() => Message = "Этот никнейм уже занят:(");
                    return;
                }

                using (FileStream fs =
                       new FileStream("D:\\БГТУ\\CursachOOP\\CursOOP\\CursOOP\\Resources\\Images\\dafault.jpg",
                           FileMode.Open))
                {
                    byte[] imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                    user.ProfileImage = imageData;
                }

                if (validateEmail() && validateName() && validatePassword())
                {

                    _unitOfWork.Users.Create(user);
                    if (Application.Current.Resources["User"] == null)
                        Application.Current.Resources.Add("User", user);
                    else
                        Application.Current.Resources["User"] = user;
                    var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
                    if (user.Role == ROLES.CLIENT)
                        mainFrame.Navigate(new CatalogPageUser());
                    else
                        mainFrame.Navigate(new CatalogPageAdmin());
                }
                else
                {
                    //Application.Current.Dispatcher.Invoke(() => Message = "Ошибка");
                }
            }
            catch{}


        }
        
        private DelegateCommand _loginRedirectCommand;
        public ICommand LoginRedirectCommand
        {
            get
            {
                if (_loginRedirectCommand == null)
                    _loginRedirectCommand = new DelegateCommand(LoginRedirect);
                return _loginRedirectCommand;
            }
        }

        private void LoginRedirect()
        {
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new Login());

        }
        
        
        private DelegateCommand _registrationRedirectCommand;
        public ICommand RegistrationRedirectCommand
        {
            get
            {
                if (_registrationRedirectCommand == null)
                    _registrationRedirectCommand = new DelegateCommand(RegisterRedirect);
                return _registrationRedirectCommand;
            }
        }

        private void RegisterRedirect()
        {
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new Registration());

        }
        private bool validatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Пароль не может быть пуст");
                return false;
            }
            if (Password.Length <= 8)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Пароль не может быть меньше 8 символов");
                return false;
            }
           
            Application.Current.Dispatcher.Invoke(() => Message = "");
            return true;
        }

        private bool validateName()
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Никнейм не может быть пуст");
                return false;
            }
            if (Password.Length <= 3)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Никнейм не может быть меньше 3 символов");
                return false;
            }
           
            Application.Current.Dispatcher.Invoke(() => Message = "");
            return true;
        }
        
        private bool validateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Почта не может быть пустой");
                return false;
            }
            else if (!Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Неверный формат почты");
                return false;
            }
            Application.Current.Dispatcher.Invoke(() => Message = "");
            return true;
        }
    }
}