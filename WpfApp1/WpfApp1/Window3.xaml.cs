using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        Recepts recepts;
        public Window3(Recepts recepts)
        {
            InitializeComponent();
            this.recepts = recepts;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < recepts.receptS.Count; i++)
            {
                if (search.Text == recepts.receptS[i].name)
                {
                    DataContext = recepts.receptS[i];
                    //type.Text = recepts.receptS[i].type;
                    //name.Text = recepts.receptS[i].name;
                    //textBludo.Text = recepts.receptS[i].textBludo;

                }
            }
        }
    }
}
