using System.Windows.Controls;
using CursOOP.ViewModels.Admin;

namespace CursOOP.Views.Admin;

public partial class UpdateBook : Page
{
    public UpdateBook()
    {
        InitializeComponent();
    }

    public UpdateBook(Guid id)
    {
        InitializeComponent();
        DataContext = new UpdateBookViewModel(id);

    }
}