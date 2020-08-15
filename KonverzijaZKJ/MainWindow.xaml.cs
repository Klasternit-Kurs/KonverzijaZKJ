using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonverzijaZKJ
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private bool _test;
		public bool Test 
		{ 
			get => _test; 
			set
			{
				_test = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Test"));
			}
		}

		public int Bla { get; set; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			ObservableCollection<Nesto> Nestos = new ObservableCollection<Nesto>();
			Nestos.Add(new Nesto("Prvi", true));
			Nestos.Add(new Nesto("Drugi", false));
			Nestos.Add(new Nesto("Treci", true));
			Nestos.Add(new Nesto("Cetvrti", false));

			dg.ItemsSource = Nestos;

		}

		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class Nesto : INotifyPropertyChanged
	{
		public string Naziv { get; set; }
		private bool _test;
		public bool Test 
		{ 
			get => _test; 
			set
			{
				_test = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Test"));
			}
		}
		public Nesto(string i, bool t)
		{
			Naziv = i;
			Test = t;
		}
		public Nesto() { }

		public event PropertyChangedEventHandler PropertyChanged;
	}

	public class IntToString : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString() == "0")
				return "";
			return value.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (int.TryParse(value.ToString(), out int br))
				return br;
			return 0;
		}
	}

	public class BoolToColor : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool b)
			{
				return b ? Colors.Green.ToString() : Colors.Red.ToString();
				if (b)
					return Colors.Green;
				else
					return Colors.Red;
			}
			return Colors.Red.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class StringToBool : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool b)
				return b.ToString();
			return "Err";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is string s)
			{
				switch(s)
				{
					case "True":
					case "Da":
					case "Yes":
						return true;
				}
			}
			return false;
			
		}
	}
}
