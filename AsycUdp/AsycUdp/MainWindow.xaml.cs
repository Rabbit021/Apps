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
using UdpServerLib;

namespace AsycUdp
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		public AsycUdpServer Server = new AsycUdpServer();

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var btn = sender as Button;
			Dispatcher.BeginInvoke(new Action(delegate
			{
				//if (string.Equals(btn.Tag.ToString(), "sender", StringComparison.CurrentCultureIgnoreCase))
					Server.SendMsg();
				//else
					Server.ReceiveMsg();
			}));
		}
	}
}
