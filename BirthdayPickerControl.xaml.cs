using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BirthdayPickerViewModel();
        }
    }
}
