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
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AsycUdpCommuncation
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

		private void sender_Click(object sender, RoutedEventArgs e)
		{
			this.Sender("I　Click！");
		}

		byte[] buffer = new byte[2048];
		public void Sender(string message)
		{
			var point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8008);
			UdpClient client = new UdpClient();
			var data = Encoding.ASCII.GetBytes(message);
			client.Send(data, data.Length);
		}
	}
}
