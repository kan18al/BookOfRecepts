using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Recepts recepts;
        Recept recept;
        public Window2(Recept rec, Recepts recs)
        {

            InitializeComponent();
            recept = rec;
            DataContext = recept;
            recepts = recs;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)//удаление блюда
        {
            for (int i = 0; i < recepts.receptS.Count; i++)
            {
                if (recepts.receptS[i] == recept)
                {
                    recepts.receptS.Remove(recepts.receptS[i]);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//изменяю изображение блюда
        {
            recept.pathImage = path.Text;
        }
    }
}
