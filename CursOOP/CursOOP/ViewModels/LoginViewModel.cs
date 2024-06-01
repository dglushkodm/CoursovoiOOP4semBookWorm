using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;
using Prism.Commands;

namespace CursOOP.ViewModels
{
    class LoginViewModel: INotifyPropertyChanged
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
        public LoginViewModel()
        {
            _unitOfWork = new UnitOfWork();
        }
        private void EnterRedirect()
        {
            try
            {
                EntityFramework.Models.User user = _unitOfWork.Users.Read().Find(b => b.Username.Equals(Username));
                if (Username == null || Password == null)
                {
                    Application.Current.Dispatcher.Invoke(() => Message = "Поля не должны быть пустыми");
                }
                else if (user != null && user.CheckPassword(_password))
                {
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
                    Application.Current.Dispatcher.Invoke(() => Message = "Неверный никнейм или пароль");
                }
            }
            catch{}


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

    }
}