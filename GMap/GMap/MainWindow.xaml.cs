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
using System.Net;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using GMap.NET.MapProviders;
using System.Linq;
using System.Xml.Linq;

namespace GMap
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.LoadMap();
			this.DataContext = this;
			var Extension = System.IO.Path.GetExtension("../test/a.file");
			this.CusTest = new Test { Name = "Test" };
			this.TestXml();
		}
		public void LoadMap()
		{
			try
			{
				IPHostEntry e = Dns.GetHostEntry("www.google.com.hk");
			}
			catch
			{
				this.mapControl.Manager.Mode = NET.AccessMode.CacheOnly;
			}

			this.mapControl.MapProvider = GMapProviders.GoogleChinaMap;
			this.mapControl.ShowCenter = false;
			mapControl.DragButton = MouseButton.Right;
			mapControl.Position = new PointLatLng(39.90403, 116.407526);
			this.mapControl.SetPositionByKeywords("beijing");
			mapControl.MouseLeftButtonDown += MapControl_MouseLeftButtonDown;
		}

		private void MapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Point click = e.GetPosition(mapControl);
			PointLatLng point = mapControl.FromLocalToLatLng((int)click.X, (int)click.Y);
			GMapMarker marker = new GMapMarker(point)
				{
					Shape = new CustomMarker()
				};
			marker.ZIndex = int.MaxValue;
			mapControl.Markers.Add(marker);
		}

		public Test CusTest { get; set; }

		public void TestXml()
		{
			FileOperation Operation = new FileOperation();
			Operation.WriteInfo(Operation.stus);
			Operation.ReadInfo(Operation.stus);
		}

	}

	public class Test : DependencyObject
	{
		public string Name { get; set; }
	}
}

