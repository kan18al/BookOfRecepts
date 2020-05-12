using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    public class Recept : INotifyPropertyChanged
    {
        string PathImage;
        string TextBludo;
        string Type;
        string Name;

        public Recept(string name, string pathImage, string textBludo, string type)
        {
            this.PathImage = pathImage;
            this.TextBludo = textBludo;
            this.Type = type;
            this.Name = name;
        }
        public string pathImage { get { return PathImage; } set { PathImage = value; OnPropertyChanged("pathImage"); } }
        public string textBludo { get { return TextBludo; } set { TextBludo = value; OnPropertyChanged("textBludo"); } }
        public string type { get { return Type; } set { Type = value; OnPropertyChanged("type"); } }
        public string name { get { return Name; } set { Name = value; OnPropertyChanged("name"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}