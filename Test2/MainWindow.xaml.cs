using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Team_project.ViewModel;

namespace Team_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }

        private void listBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dataGridItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}