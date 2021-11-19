using NetworkService.Core;
using NetworkService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.ViewModel
{
    class MainWindowViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; } 
        private NetworkDataViewModel networkDataViewModel = new NetworkDataViewModel();
        private NetworkViewViewModel networkViewViewModel = new NetworkViewViewModel();
        private DataChartViewModel dataChartViewModel = new DataChartViewModel();
        private BindableBase currentViewModel; 
        public int monitor = 0;
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = networkDataViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "NetworkData":
                    CurrentViewModel = networkDataViewModel;
                    break;
                case "NetworkView":
                    CurrentViewModel = networkViewViewModel;
                    break;

                case "DataChart":
                    CurrentViewModel = dataChartViewModel;
                    break;
            }
        }
    }
}
