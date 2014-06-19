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

namespace DesignPattern
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;

			GetClientObject();
		}

		private void GetClientObject()
		{
			PackDelvFactory factory = new StandardFactory();

			Client standard = new Client(factory);
			this.Package = standard.Packaging.GetType().ToString();
			this.Deliver = standard.DeliverDocument.GetType().ToString();

			PackDelvFactory df = new ShockProofFactory();
			Client delicate = new Client(df);
			this.ShockPackage = delicate.Packaging.GetType().ToString();
			this.ShockDeliver = delicate.DeliverDocument.GetType().ToString();
		}

		#region Package
		public string Package
		{
			get { return (string)GetValue(PackageProperty); }
			set { SetValue(PackageProperty, value); }
		}

		public static readonly DependencyProperty PackageProperty =
			DependencyProperty.Register("Package", typeof(string), typeof(MainWindow), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as MainWindow;
				if (vm == null) return;
			}));

		#endregion
		#region Deliver
		public string Deliver
		{
			get { return (string)GetValue(DeliverProperty); }
			set { SetValue(DeliverProperty, value); }
		}

		public static readonly DependencyProperty DeliverProperty =
			DependencyProperty.Register("Deliver", typeof(string), typeof(MainWindow), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as MainWindow;
				if (vm == null) return;
			}));

		#endregion

		#region ShockPackage
		public string ShockPackage
		{
			get { return (string)GetValue(ShockPackageProperty); }
			set { SetValue(ShockPackageProperty, value); }
		}

		public static readonly DependencyProperty ShockPackageProperty =
			DependencyProperty.Register("ShockPackage", typeof(string), typeof(MainWindow), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as MainWindow;
				if (vm == null) return;
			}));

		#endregion
		#region ShockDeliver
		public string ShockDeliver
		{
			get { return (string)GetValue(ShockDeliverProperty); }
			set { SetValue(ShockDeliverProperty, value); }
		}

		public static readonly DependencyProperty ShockDeliverProperty =
			DependencyProperty.Register("ShockDeliver", typeof(string), typeof(MainWindow), new PropertyMetadata((sender, e) =>
			{
				var vm = sender as MainWindow;
				if (vm == null) return;
			}));

		#endregion

	}
}
