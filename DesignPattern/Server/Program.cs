using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		public void Comunication()
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			IPAddress ip;
			if (!IPAddress.TryParse("", out ip)) return;
			IPEndPoint point = new IPEndPoint(ip, int.Parse("8888"));
			socket.Bind(point);
			socket.Listen(3);

			Thread th = new Thread(Listen);
			th.IsBackground = true;
			th.Start();

		}

		private void Listen(object obj)
		{

			while (true)
			{

			}
		}
	}
}

