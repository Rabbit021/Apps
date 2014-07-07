using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoMapperTest.Models;
using AutoMapper;

namespace AutoMapperTest
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += MainWindow_Loaded;
		}
		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			this.DataContext = MainWindowVM.Instance;
			MainWindowVM.Instance.Loaded();
		}
	}

	public class MainWindowVM : DependencyObject
	{
		#region Instance
		private static MainWindowVM instance = new MainWindowVM();
		public static MainWindowVM Instance { get { return instance; } }
		private MainWindowVM()
		{
		}
		public void Loaded()
		{
			this.Init();
		}
		private void Init()
		{
			Weather.Instance.GetWeatherCommplete -= Instance_GetWeatherCommplete;
			Weather.Instance.GetWeatherCommplete += Instance_GetWeatherCommplete;
			Weather.Instance.GetWeather("北京");
		}

		void Instance_GetWeatherCommplete(object sender, RoutedEventArgs e)
		{
			this.CurrentWeather = e as WeatherData;
		}
		#endregion

		#region CurrentWeather
		public WeatherData CurrentWeather
		{
			get { return (WeatherData)GetValue(CurrentWeatherProperty); }
			set { SetValue(CurrentWeatherProperty, value); }
		}

		public static readonly DependencyProperty CurrentWeatherProperty =
			DependencyProperty.Register("CurrentWeather", typeof(WeatherData), typeof(MainWindowVM), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as MainWindowVM;
				if (vm == null) return;
			}));


		#region Test
		public int Test
		{
			get { return (int)GetValue(TestProperty); }
			set { SetValue(TestProperty, value); }
		}

		public static readonly DependencyProperty TestProperty =
			DependencyProperty.Register("Test", typeof(int), typeof(MainWindowVM),
			new PropertyMetadata(
				(sender, e) =>
				{
					var vm = sender as MainWindowVM;
					if (vm == null) return;
				}
			),

			new ValidateValueCallback(x => { return true; }));

		#endregion

		#endregion
	}
}
