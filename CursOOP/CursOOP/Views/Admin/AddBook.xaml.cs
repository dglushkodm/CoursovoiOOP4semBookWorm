using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CursOOP.ViewModels.Admin;
using EntityFramework;
using EntityFramework.Models;

namespace CursOOP.Views.Admin;

public partial class AddBook : Page
{
   
    
   
    private UnitOfWork _unitOfWork;
    public AddBook()
    {
        InitializeComponent();
        _unitOfWork = new UnitOfWork();
       
       
    }
   

  
}