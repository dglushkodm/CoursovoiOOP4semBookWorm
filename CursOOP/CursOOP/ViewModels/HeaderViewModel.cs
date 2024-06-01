using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.ViewModels;

public class HeaderViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    
    ResourceDictionary dictEng;
    ResourceDictionary dictRus;
    ResourceDictionary darkTheme;
    ResourceDictionary brightTheme;
    private UnitOfWork _unitOfWork;
    private EntityFramework.Models.User _user;
    public HeaderViewModel()
    {
        dictEng = new ResourceDictionary() { Source = new Uri("Resources/Languages/EN.xaml", UriKind.Relative) };
        dictRus = new ResourceDictionary() { Source = new Uri("Resources/Languages/RU.xaml", UriKind.Relative) };
        darkTheme = new ResourceDictionary() { Source = new Uri("Resources/Themes/Dark.xaml", UriKind.Relative) };
        brightTheme = new ResourceDictionary() { Source = new Uri("Resources/Themes/Bright.xaml", UriKind.Relative) };
        _unitOfWork = new UnitOfWork();
        _user = (EntityFramework.Models.User)Application.Current.Resources["User"];
        EntityFramework.Models.User user = _unitOfWork.Users.Read().Find(u => u.Id == _user.Id);
        Img = user.ProfileImage;
    }
    private DelegateCommand _switchAppearanceCommand;
    public ICommand SwitchAppearanceCommand
    {
        get
        {
            if (_switchAppearanceCommand == null)
                _switchAppearanceCommand = new DelegateCommand(SwitchAppearance);
            return _switchAppearanceCommand;
        }
    }

    private void SwitchAppearance()
    {
        if (Application.Current.Resources["Appearance"] == "Light")
        {
            Application.Current.Resources.MergedDictionaries.Remove(brightTheme);
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
            Application.Current.Resources["Appearance"] = "Dark";
        }
        else
        {
            Application.Current.Resources.MergedDictionaries.Remove(darkTheme);
            Application.Current.Resources.MergedDictionaries.Add(brightTheme);
            Application.Current.Resources["Appearance"] = "Light";
        }
    }

    
    private DelegateCommand _switchLanguageCommand;
    public ICommand SwitchLanguageCommand
    {
        get
        {
            if (_switchLanguageCommand == null)
                _switchLanguageCommand = new DelegateCommand(SwitchLanguage);
            return _switchLanguageCommand;
        }
    }

    Frame mainFrame = Application.Current.Resources["MainFrame"] as Frame;
    Frame frame = Application.Current.Resources["HomePageFrame"] as Frame;
    private DelegateCommand _undoCommand;
    public ICommand UndoCommand
    {
        get
        {
            if (_undoCommand == null)
                _undoCommand = new DelegateCommand(Udno);
            return _undoCommand;
        }
    }

    private void Udno()
    {
        if (mainFrame.CanGoBack)
        {
            mainFrame.GoBack();
        }

        if (frame.CanGoBack)
        {
            frame.GoBack();
        }
            
    }

    
    private DelegateCommand _exitCommand;
    public ICommand ExitCommand
    {
        get
        {
            if (_exitCommand == null)
                _exitCommand = new DelegateCommand(Exit);
            return _exitCommand;
        }
    }

    private void Exit()
    {
        var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            mainFrame.Navigate(new Login());
       
      

    }

    private DelegateCommand _redoCommand;
    public ICommand RedoCommand
    {
        get
        {
            if (_redoCommand == null)
                _redoCommand = new DelegateCommand(Redo);
            return _redoCommand;
        }
    }

    private void Redo()
    {
        if (mainFrame.CanGoForward)
        {
            mainFrame.GoForward();
        }

    }
    private byte[] _img;
    public byte[] Img
    {
        get => _img;
        set
        {
            _img = value;
            OnPropertyChanged(nameof(Img));
        }
    }
    
    private DelegateCommand _homeCommand;
    public ICommand HomeCommand
    {
        get
        {
            if (_homeCommand == null)
                _homeCommand = new DelegateCommand(Home);
            return _homeCommand;
        }
    }

    private void Home()
    {
        var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
        if(_user.Role == ROLES.ADMIN)
            mainFrame.Navigate(new CatalogPageAdmin());
        else
        {
            mainFrame.Navigate(new CatalogPageUser());
        }
    }
    
    private DelegateCommand _accountRedirectCommand;
    public ICommand AccountRedirectCommand
    {
        get
        {
            if (_accountRedirectCommand == null)
                _accountRedirectCommand = new DelegateCommand(AccountRedirect);
            return _accountRedirectCommand;
        }
    }

    private void AccountRedirect()
    {
        var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
        mainFrame.Navigate(new AccountUser());

    }
    private void SwitchLanguage()
    {
        //Application.Current.Resources.MergedDictionaries.Clear();
        if (Application.Current.Resources["Language"] == "En")
        {
            Application.Current.Resources.MergedDictionaries.Remove(dictEng);
            Application.Current.Resources.MergedDictionaries.Add(dictRus);
            Application.Current.Resources["Language"] = "Ru";
        }
        else
        {
            Application.Current.Resources.MergedDictionaries.Remove(dictRus);
            Application.Current.Resources.MergedDictionaries.Add(dictEng);
            Application.Current.Resources["Language"] = "En";
        }

    }
}