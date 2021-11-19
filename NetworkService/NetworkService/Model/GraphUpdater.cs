using NetworkService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
	public class GraphUpdater : BindableBase
	{
		private double firstBindingPoint;
		public double FirstBindingPoint
		{
			get { return firstBindingPoint; }
			set
			{
				SecondBindingPoint = firstBindingPoint;
				firstBindingPoint = value;
				OnPropertyChanged("FirstBindingPoint");
			}
		}

		private double firstBindingPoint1;
		public double FirstBindingPoint1
		{
			get { return firstBindingPoint1; }
			set
			{

					SecondBindingPoint1 = firstBindingPoint1;
					firstBindingPoint1 = value;
					OnPropertyChanged("FirstBindingPoint1");
				
			}
		}

		private string firstBindingPoint2;
		public string FirstBindingPoint2
		{
			get { return firstBindingPoint2; }
			set
			{
				SecondBindingPoint2 = firstBindingPoint2;
				firstBindingPoint2 = value;
				OnPropertyChanged("FirstBindingPoint2");
			}
		}

		private double secondBindingPoint;
		public double SecondBindingPoint
		{
			get { return secondBindingPoint; }
			set
			{
				ThirdBindingPoint = secondBindingPoint;
				secondBindingPoint = value;
				OnPropertyChanged("SecondBindingPoint");
			}
		}

		private double secondBindingPoint1;
		public double SecondBindingPoint1
		{
			get { return secondBindingPoint1; }
			set
			{
				ThirdBindingPoint1 = secondBindingPoint1;
				secondBindingPoint1 = value; ;
				OnPropertyChanged("SecondBindingPoint1");
			}
		}


		private string secondBindingPoint2;
		public string SecondBindingPoint2
		{
			get { return secondBindingPoint2; }
			set
			{
				ThirdBindingPoint2 = secondBindingPoint2;
				secondBindingPoint2 = value; ;
				OnPropertyChanged("SecondBindingPoint2");
			}
		}

		private double thirdBindingPoint;
		public double ThirdBindingPoint
		{
			get { return thirdBindingPoint; }
			set
			{
				FourthBindingPoint = thirdBindingPoint;
				thirdBindingPoint = value;
				OnPropertyChanged("ThirdBindingPoint");
			}
		}


		private double thirdBindingPoint1;
		public double ThirdBindingPoint1
		{
			get { return thirdBindingPoint1; }
			set
			{
				FourthBindingPoint1 = thirdBindingPoint1;
				thirdBindingPoint1 = value;
				OnPropertyChanged("ThirdBindingPoint1");
			}
		}

		private string thirdBindingPoint2;
		public string ThirdBindingPoint2
		{
			get { return thirdBindingPoint2; }
			set
			{
				FourthBindingPoint2 = thirdBindingPoint2;
				thirdBindingPoint2 = value;
				OnPropertyChanged("ThirdBindingPoint2");
			}
		}

		private double fourthBindingPoint;
		public double FourthBindingPoint
		{
			get { return fourthBindingPoint; }
			set
			{
				FifthBindingPoint = fourthBindingPoint;
				fourthBindingPoint = value;
				OnPropertyChanged("FourthBindingPoint");
			}
		}


		private double fourthBindingPoint1;
		public double FourthBindingPoint1
		{
			get { return fourthBindingPoint1; }
			set
			{
				FifthBindingPoint1 = fourthBindingPoint1;
				fourthBindingPoint1 = value;
				OnPropertyChanged("FourthBindingPoint1");
			}
		}

		private string fourthBindingPoint2;
		public string FourthBindingPoint2
		{
			get { return fourthBindingPoint2; }
			set
			{
				FifthBindingPoint2 = fourthBindingPoint2;
				fourthBindingPoint2 = value;
				OnPropertyChanged("FourthBindingPoint2");
			}
		}

		private double fifthBindingPoint;
		public double FifthBindingPoint
		{
			get { return fifthBindingPoint; }
			set
			{
				fifthBindingPoint = value;
				OnPropertyChanged("FifthBindingPoint");
			}
		}

		private double fifthBindingPoint1;
		public double FifthBindingPoint1
		{
			get { return fifthBindingPoint1; }
			set
			{
				fifthBindingPoint1 = value;
				OnPropertyChanged("FifthBindingPoint1");
			}
		}

		private string fifthBindingPoint2;
		public string FifthBindingPoint2
		{
			get { return fifthBindingPoint2; }
			set
			{
				fifthBindingPoint2 = value;
				OnPropertyChanged("FifthBindingPoint2");
			}
		}


	}
}
