using System.Windows.Controls;
using CursOOP.ViewModels.Admin;

namespace CursOOP.Views.Admin;

public partial class AddChapter : Page
{
    public AddChapter()
    {
        InitializeComponent();
    }
    public AddChapter(Guid id)
    {
        InitializeComponent();
        DataContext = new AddChapterViewModel(id);

    }
}