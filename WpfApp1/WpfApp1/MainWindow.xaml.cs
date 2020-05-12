using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Recepts recepts;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = recepts = new Recepts();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window1 rec_create = new Window1(recepts);
            rec_create.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Recept recept = (Recept)button.DataContext;
            Window2 wind = new Window2(recept, recepts);
            wind.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 wind = new Window3(recepts);
            wind.Show();
        }
    }
}