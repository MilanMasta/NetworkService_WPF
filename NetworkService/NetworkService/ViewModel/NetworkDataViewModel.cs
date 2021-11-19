using NetworkService.Core;
using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkService.ViewModel
{
    public class NetworkDataViewModel : BindableBase
    {
        private DataBase dataBase = new DataBase();
        public List<Server> SerachServers = new List<Server>();
        public ObservableCollection<Server> CopyServers { get; set; } = new ObservableCollection<Server>();
        public List<string> ComboBoxData { get; set; }      //kombo box za pretragu 
        public List<string> ComboBoxDataServers { get; set; }   // za dodavanje reactora
        public MyICommand AddCommand { get; set; }      //komande za dugmice
        public MyICommand DeleteCommand { get; set; }
        public MyICommand SearchCommand { get; set; }
        public MyICommand SaveSearchCommand { get; set; }
        public MyICommand NameSearchCommand { get; set; }
        public MyICommand TypeSearchCommand { get; set; }
        public MyICommand ApplaySearchCommand { get; set; }

        //id reaktora kako dodamo novi id se poveca
        private static int id = 0;      //na svaki od ovih se povezuje nesto iz networkDataView
        private string idSearch;
        private string typeText;
        private string searchValueText;
        private int nameOrType = -1;
        private int index = -1;
        private string path;
        private int clickSearch = 0;
        private string nameButtonSearch = "Search";
        string pathSaveSearch = Environment.CurrentDirectory + @"\SaveSearch.txt";
        private string valueName;
        private string valueId;
        public NetworkDataViewModel()
        {
            ComboBoxData = new List<string>();
            ComboBoxDataServers = new List<string> { "Cluster", "Proxy" };
            using (StreamReader sr = new StreamReader(pathSaveSearch))
            {
                List<List<string>> fileData = new List<List<string>>();
                string textFile = sr.ReadToEnd();
                string[] split = textFile.Split('\n', '\r');
                for (int i = 0; i < split.Count(); i++)
                {
                    if (split[i] != "")
                        ComboBoxData.Add(split[i]);
                }
            }
            ValueName = "True";
            NameOrType = 0;
            AddCommand = new MyICommand(OnAdd, CanAdd);
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
            SearchCommand = new MyICommand(OnSearch, CanSearch);
            NameSearchCommand = new MyICommand(OnName);
            TypeSearchCommand = new MyICommand(OnType);
            SaveSearchCommand = new MyICommand(OnSaveSearch, CanSearch);
            ApplaySearchCommand = new MyICommand(OnApplaySearch, CanApplaySearch);
        }

        public DataBase DataBase
        { get => dataBase; set => dataBase = value; }

        public int NameOrType
        {
            get { return nameOrType; }
            set
            {
                nameOrType = value;
            }
        }

        public string IdSearch
        {
            get { return idSearch; }
            set
            {
                idSearch = value;
                OnPropertyChanged("IdSearch");   //kad properti dobije vrednost vrednost se setuje u xaml i obrnuto         
                ApplaySearchCommand.RaiseCanExecuteChanged();  //
                SearchCommand.RaiseCanExecuteChanged();
            }
        }
        public string TypeText
        {
            get { return typeText; }
            set
            {
                typeText = value;
                OnPropertyChanged("TypeText");
                Path = Environment.CurrentDirectory;
                Path = Path.Remove(Path.Length - 10, 10);
                Path += @"\Images\" + value + ".jpg";
                AddCommand.RaiseCanExecuteChanged(); //properti dobio vrednost proveri da li moze da se aktivira button koji je povezan na ovu komandu
            }
        }
        public string SearchValueText
        {
            get { return searchValueText; }
            set
            {
                searchValueText = value;
                OnPropertyChanged("SearchValueText");
                SearchCommand.RaiseCanExecuteChanged();
                SaveSearchCommand.RaiseCanExecuteChanged();
            }
        }
        public int Index
        {
            get { return index; }
            set
            {
                index = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                OnPropertyChanged("Path");
            }
        }
        public int ClickSearch
        {
            get { return clickSearch; }
            set
            {
                clickSearch = value;
                if (value == 0)
                    NameButtonSearch = "Search";
                else
                    NameButtonSearch = "UndoSearch";
            }
        }
        public string NameButtonSearch
        {
            get { return nameButtonSearch; }
            set
            {
                nameButtonSearch = value;
                OnPropertyChanged("NameButtonSearch");
            }
        }

        public string ValueName
        {
            get { return valueName; }
            set
            {
                valueName = value;
                OnPropertyChanged("ValueName");
            }
        }

        public string ValueId
        {
            get { return valueId; }
            set
            {
                valueId = value;
                OnPropertyChanged("ValueId");
            }
        }
       
        private bool CanDelete()
        {
            return index >= 0;
        }
        private void OnDelete()
        {
            bool valid = true;
            foreach (Server v in DataBase.CanvasObjects.Values)   
            {
                if (v.Name == DataBase.Servers[index].Name)
                {
                    valid = false;
                    MessageBox.Show("Server pod monitoringom", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
            }

            if (valid)
                DataBase.Servers.RemoveAt(Index);
        }

        private bool CanAdd()
        {
            if (TypeText != null)   //provera da li je odabran tip reaktora
                return true;
            return false;
        }
        private void OnAdd()
        {
            Server s = new Server();
            s.Id = id++;
            s.Name = TypeText + "_" + s.Id.ToString();
            s.Ip = "192.168.1:0" + s.Id;
            string pathImg = Environment.CurrentDirectory;
            pathImg = pathImg.Remove(pathImg.Length - 10, 10);
            pathImg += @"\Images\" + TypeText + ".jpg";
            s.Slika = pathImg;
            DataBase.Servers.Add(s);  //nakon ovoga je u tabeli
        }

        private void OnName()
        {
            NameOrType = 0;
        }
        public void OnType()
        {
            NameOrType = 1;
        }

        private bool CanSearch()
        {
            if (SearchValueText != null)
                return true;
            return false;
        }
        private void OnSearch()
        {
            if (ClickSearch == 0)    //1 kad moze undo inace 0
            {
                foreach (Server r in DataBase.Servers)
                {
                    CopyServers.Add(r);
                }

                if (NameOrType == 0)
                {
                    foreach (var item in DataBase.Servers)
                    {
                        if (item.Name.Contains(SearchValueText))
                        {
                            SerachServers.Add(item);
                        }
                    }
                }
                else if (NameOrType == 1)
                {
                    foreach (var item in DataBase.Servers)
                    {
                        if (item.Name.Contains(SearchValueText))
                        {
                            SerachServers.Add(item);
                        }
                    }
                }
                DataBase.Servers.Clear();
                foreach (Server v in SerachServers)
                {
                    DataBase.Servers.Add(v);
                }
                SerachServers.Clear();
                ClickSearch = 1;

            }
            else
            {
                DataBase.Servers.Clear();
                foreach (Server v in CopyServers)
                {
                    DataBase.Servers.Add(v);
                }
                CopyServers.Clear();
                ClickSearch = 0;
            }
        }

        public void OnSaveSearch()
        {
            string valueSearch = "";    //kriterijum pretrage
            if (NameOrType == 0)
            {
                valueSearch += "Name ";
            }
            else
            {
                valueSearch += "Type ";
            }
            valueSearch += SearchValueText;
            StreamWriter writer;
            using (writer = new StreamWriter(pathSaveSearch, true))
            {
                writer.WriteLine(valueSearch);
            }
        }

        public void OnApplaySearch()
        {
            string value = IdSearch; //idsearch kriterijum pretrage
            string[] split = value.Split(' ');
            if (split[0] == "Name")
            {
                ValueName = "True";
            }
            else
            {
                ValueId = "True";
            }
            SearchValueText = split[1];
        }

        public bool CanApplaySearch()
        {
            if (IdSearch != null)
                return true;
            return false;
        }
    }


}
