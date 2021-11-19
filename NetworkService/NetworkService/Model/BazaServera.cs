using System.Collections.Generic;
using System.Collections.ObjectModel;
using NetworkService.Core;

namespace NetworkService.Model
{

    public class DataBase
    {
        public static ObservableCollection<Server> Servers { get; set; } = new ObservableCollection<Server>();
        public static Dictionary<string, Server> CanvasObjects { get; set; } = new Dictionary<string, Server>();
    }

    public class Server : BindableBase
    {
        private int id;
        private string name;
        private string ip;
        private string slika;
        private double value;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public string Ip
        {
            get { return ip; }
            set
            {
                ip = value;
            }
        }
        public string Slika
        {
            get { return slika; }
            set
            {
                slika = value;
            }
        }

        public double Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
                if (value <= 75 && value >= 45)
                {
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint = ViewModel.DataChartViewModel.CalculateElementHeight(value);
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint1 = (ViewModel.DataChartViewModel.CalculateElementHeight(value)) / 2;
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint2 = "#4cf7db";
                }
                else
                {
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint = ViewModel.DataChartViewModel.CalculateElementHeight(value);
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint1 = (ViewModel.DataChartViewModel.CalculateElementHeight(value)) / 2;
                    ViewModel.DataChartViewModel.ElementHeights.FirstBindingPoint2 = "#ff4c4c";
                }
            }
        }

        public Server()
        {
        }
        public Server(Server s)
        {
            Id = s.Id;
            Name = s.Name;
            Ip = s.Ip;
            slika = s.slika;
            Value = s.Value;
        }
    }


}
