using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UdpServer
{
	class Program
	{
		private static Program instance = new Program();

		#region Field
		Socket client = null;
		int port = 8008;
		byte[] buffer = new byte[2048];
		#endregion

		IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 5434);

		static void Main(string[] args)
		{
			UdpClient client = new UdpClient(instance.localEndPoint);

			client.BeginReceive(new AsyncCallback(instance.ReceiveCompleted), client);
		}

		private void ReceiveCompleted(IAsyncResult ar)
		{
			try
			{
				var scok = ar.AsyncState as UdpClient;
				var res = scok.EndReceive(ar, ref localEndPoint);
				string str = Encoding.ASCII.GetString(res);
				Console.WriteLine(str);
				scok.BeginReceive(new AsyncCallback(instance.ReceiveCompleted), scok);
			}
			catch (Exception exp)
			{

			}

		}


	}
}
