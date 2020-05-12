using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApp1.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            this.PATH = path;
        }

        public ObservableCollection<Recept> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new ObservableCollection<Recept>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Recept>>(fileText);
            }
        }

        public void SaveData(ObservableCollection<Recept> recepts)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(recepts);
                writer.Write(output);
            }
        }
    }
}