using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using CursOOP.Views.Admin;
using CursOOP.Views.User;
using EntityFramework;
using EntityFramework.Models;
using Microsoft.Win32;

namespace CursOOP.ViewModels.Admin;

public class AddChapterViewModel : INotifyPropertyChanged
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
    
    private string _number;
    public string Number
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
    
    private string _filename;
    public string FileName
    {
        get => _filename;
        set
        {
            _filename = value;
            OnPropertyChanged(nameof(FileName));
        }
    }
    
    private string _filetext;
    public string FileText
    {
        get => _filetext;
        set
        {
            _filetext = value;
            OnPropertyChanged(nameof(FileText));
        }
    }
    
    private string _message;
    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged(nameof(Message));
        }
    }
    
    private DelegateCommand _createCommand;

    public ICommand AddCommand
    {
        get
        {
            if (_createCommand == null)
                _createCommand = new DelegateCommand(Add);
            return _createCommand;
        }
    }

    private void Add()
    {
        try
        {
            if (Name == String.Empty || Number == String.Empty || Volume == String.Empty || FileText == null)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Все поля должны быть заполнены");
            }
            else if (!int.TryParse(Number, out int valuee) || valuee < 0)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Неккоректный номер главы");
            }
            else
            {


                var chapter = new Chapter
                {
                    Name = _name, Number = int.Parse(_number), Volume = _volume, DateUpload = DateTime.Now.Date,
                    BookId = _book.Id, Text = FileText
                };
                _unitOfWork.Chapters.Create(chapter);
                var mainFrame = Application.Current.Resources["MainFrame"] as Frame;
                mainFrame.Navigate(new BookInf(_book.Id));
            }
        }
        catch{}
    }
    
    private DelegateCommand _textCommand;

    public ICommand UploadText
    {
        get
        {
            if (_textCommand == null)
                _textCommand = new DelegateCommand(ChooseText);
            return _textCommand;
        }
    }

    private void ChooseText()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files (*.txt)|*.txt";

        if (openFileDialog.ShowDialog() == true)
        {
            
            string selectedFilePath = openFileDialog.FileName;
            FileName = Path.GetFileName(selectedFilePath);

            try
            {
                FileText = File.ReadAllText(selectedFilePath);
               // XDocument xmlDocument = new XDocument(new XElement("Content", FileText));
                //FileText = xmlDocument.ToString();
               /* string[] lines = File.ReadAllLines(selectedFilePath);
                
                foreach (string line in lines)
                {
                    FileText += "\n" + line;
                }*/
            }
            catch (IOException ex)
            {
                Application.Current.Dispatcher.Invoke(() => Message = "Ошибка чтения файла");
            }
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
    
    private Book _book;
    private UnitOfWork _unitOfWork; 
    public AddChapterViewModel()
    {
        
    }
    public AddChapterViewModel(Guid id)
    {
        _unitOfWork = new UnitOfWork();
        _book = _unitOfWork.Books.Read().Find(b => b.Id.Equals(id));
    }
    
}