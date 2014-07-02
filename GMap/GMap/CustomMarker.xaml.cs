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
using GMap.NET.WindowsPresentation;

namespace GMap
{
	/// <summary>
	/// CustomMarker.xaml 的交互逻辑
	/// </summary>
	public partial class CustomMarker : UserControl
	{
		public CustomMarker()
		{
			InitializeComponent();
		}

		private void Btn_Click(object sender, RoutedEventArgs e)
		{
			this.NewBtn.Visibility = System.Windows.Visibility.Visible;
		}
	}
}
