using NetworkService.Core;
using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.ViewModel
{
    public class DataChartViewModel : BindableBase
    {
        public static GraphUpdater ElementHeights { get; set; } = new GraphUpdater();

        public static double CalculateElementHeight(double value)
        {
                return value*2;
        }
    }
        
 }
