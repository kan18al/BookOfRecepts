using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Recepts recepts;
        public Window1(Recepts recepts)
        {
            this.recepts = recepts;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (type.Text == "one" || type.Text == "two" || type.Text == "salat" || type.Text == "desert")
            {
                Recept Temp = new Recept(name.Text, image_path.Text, text_bludo.Text, type.Text);
                recepts.receptS.Add(Temp);
            }
            else
            {
                MessageBox.Show("поддерживаются такие типы рецептов: \"one\", \"two\", \"salat\", \"desert\"");
            }
            Close();
        }
    }
}