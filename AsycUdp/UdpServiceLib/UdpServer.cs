using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UdpServerLib
{
	public class AsycUdpServer
	{
		//节点
		private IPEndPoint ipEndPoint = null;
		private IPEndPoint remoteEP = null;
		//发送和接收
		private UdpClient udpReviver = null;
		private UdpClient udpSender = null;
		//端口
		private const int listenPort = 1101;
		private const int remotePort = 1100;
		//发送接收状态
		UdpState udpReciverState = null;
		UdpState udpSenderState = null;

		//状态同步
		private ManualResetEvent sendDone = new ManualResetEvent(false);
		private ManualResetEvent receiveDone = new ManualResetEvent(false);

		public AsycUdpServer()
		{
			//本机节点
			this.ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
			//远程节点
			this.remoteEP = new IPEndPoint(Dns.GetHostAddresses(Dns.GetHostName())[0], remotePort);

			this.udpReviver = new UdpClient(this.ipEndPoint);
			this.udpReviver.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			this.udpSender = new UdpClient(this.remoteEP);
			this.udpSender.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

			//
			this.udpReciverState = new UdpState
			{
				udpClient = this.udpReviver,
				ipEndPoint = this.ipEndPoint
			};

			this.udpSenderState = new UdpState
			{
				udpClient = this.udpSender,
				ipEndPoint = this.remoteEP
			};
		}

		#region 接收 和接受回调
		public void ReceiveMsg()
		{
			while (true)
			{
				lock (this)
				{
					IAsyncResult iar = udpReviver.BeginReceive(new AsyncCallback(ReceiveCallback), udpReciverState);
					receiveDone.WaitOne();
					//Thread.Sleep(1000);
				}
			}
		}
		public void ReceiveCallback(IAsyncResult iar)
		{
			UdpState udpReceiveState = iar.AsyncState as UdpState;
			if (iar.IsCompleted)
			{
				Byte[] receiveBytes = udpReceiveState.udpClient.EndReceive(iar, ref this.udpReciverState.ipEndPoint);

				string receiveString = Encoding.ASCII.GetString(receiveBytes);
				Console.WriteLine("Received: {0}", receiveString);
				receiveDone.Set();
				SendMsg();
			}
		}
		#endregion

		#region 发送和回调
		public void SendMsg()
		{
			udpSender.Connect(udpSenderState.ipEndPoint);
			udpSenderState.udpClient = udpSender;
			udpSenderState.counter++;

			string message = string.Format("第{0}个UDP请求处理完成！", udpSenderState.counter);
			Byte[] sendBytes = Encoding.Unicode.GetBytes(message);
			udpSender.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SenderCallBack), udpSenderState);
			sendDone.WaitOne();
		}
		public void SenderCallBack(IAsyncResult iar)
		{
			UdpState udpState = iar.AsyncState as UdpState;
			Console.WriteLine("第{0}个请求处理完毕！", udpState.counter);
			Console.WriteLine("number of bytes sent: {0}", udpState.udpClient.EndSend(iar));
			sendDone.Set();
		}
		#endregion
	}

	public class UdpState
	{
		public UdpClient udpClient;
		public IPEndPoint ipEndPoint;
		public const int BufferSize = 1024;
		public byte[] buffer = new byte[BufferSize];
		public int counter = 0;
	}
}
