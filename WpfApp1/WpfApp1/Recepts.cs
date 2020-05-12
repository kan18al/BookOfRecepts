using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Services;

namespace WpfApp1
{
    public class Recepts
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private FileIOService _fileIOService;

        ObservableCollection<Recept> recepts = new ObservableCollection<Recept>();
        ObservableCollection<Recept> recepts_one = new ObservableCollection<Recept>();
        ObservableCollection<Recept> recepts_two = new ObservableCollection<Recept>();
        ObservableCollection<Recept> recepts_salat = new ObservableCollection<Recept>();
        ObservableCollection<Recept> recepts_desert = new ObservableCollection<Recept>();

        public ObservableCollection<Recept> receptS => recepts;
        public ObservableCollection<Recept> receptS_one => recepts_one;
        public ObservableCollection<Recept> receptS_two => recepts_two;
        public ObservableCollection<Recept> receptS_salat => recepts_salat;
        public ObservableCollection<Recept> receptS_desert => recepts_desert;

        public Recepts()
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                recepts = _fileIOService.LoadData();//загружаю рецепты с файла
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            recepts.CollectionChanged += Recepts_CollectionChanged;
            sort();//сортирую рецепты по типу
        }

        private void Recepts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)//для отслеживания изменений
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {

                switch (recepts[e.NewStartingIndex].type)//проверяю какого типа новый добавленный рецепт
                {
                    case "one":
                        recepts_one.Add(recepts[e.NewStartingIndex]);
                        break;
                    case "two":
                        recepts_two.Add(recepts[e.NewStartingIndex]);
                        break;
                    case "salat":
                        recepts_salat.Add(recepts[e.NewStartingIndex]);
                        break;
                    case "desert":
                        recepts_desert.Add(recepts[e.NewStartingIndex]);
                        break;
                    default:
                        break;
                }
                _fileIOService.SaveData(recepts);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                _fileIOService.SaveData(recepts);//сохраняю изменения
            }
        }

        private void sort()//сортировка для дерева
        {
            for (int i = 0; i < recepts.Count; i++)
            {
                switch (recepts[i].type)
                {
                    case "one":
                        recepts_one.Add(recepts[i]);
                        break;
                    case "two":
                        recepts_two.Add(recepts[i]);
                        break;
                    case "salat":
                        recepts_salat.Add(recepts[i]);
                        break;
                    case "desert":
                        recepts_desert.Add(recepts[i]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}