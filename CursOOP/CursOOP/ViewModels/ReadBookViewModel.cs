using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CursOOP.Views;
using CursOOP.Views.Admin;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.ViewModels;

public class ReadBookViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    
    private int _number;
    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            OnPropertyChanged(nameof(Number));
        }
    }
    
    private string _volume;
    public string Volume
    {
        get => _volume;
        set
        {
            _volume = value;
            OnPropertyChanged(nameof(Volume));
        }
    }
    
    private string _text;
    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged(nameof(Text));
        }
    }
    private DelegateCommand _RedirectCommand;
    public ICommand RedirectCommand
    {
        get
        {
            if (_RedirectCommand == null)
                _RedirectCommand = new DelegateCommand(NextRedirect);
            return _RedirectCommand;
        }
    }

    private void NextRedirect()
    {
        try
        {
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            var chap = _unitOfWork.Chapters.Read()
                .Find(b => b.Number.Equals(Number + 1) && b.BookId.Equals(_chapter.BookId));
            mainFrame.Navigate(new ReadBook(chap));
        }
        catch{}
    }

    private DelegateCommand _RedirectBackCommand;
    public ICommand RedirectBackCommand
    {
        get
        {
            if (_RedirectBackCommand == null)
                _RedirectBackCommand = new DelegateCommand(BackRedirect);
            return _RedirectBackCommand;
        }
    }

    private void BackRedirect()
    {
        try
        {
            var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
            var chap = _unitOfWork.Chapters.Read()
                .Find(b => b.Number.Equals(Number - 1) && b.BookId.Equals(_chapter.BookId));
            mainFrame.Navigate(new ReadBook(chap));
        }
        catch{}

    }
    
    private DelegateCommand _read;
    private UnitOfWork _unitOfWork;
    private Chapter _chapter;
    
    public ReadBookViewModel(){}
    public ReadBookViewModel(Chapter chapt)
    {
        _unitOfWork = new UnitOfWork();
        _chapter = _unitOfWork.Chapters.Read().Find(b => b.Id.Equals(chapt.Id));
        
        Name = _chapter.Name;
        Text = _chapter.Text;
        Number = _chapter.Number;
        Volume = _chapter.Volume;
    }
    
}