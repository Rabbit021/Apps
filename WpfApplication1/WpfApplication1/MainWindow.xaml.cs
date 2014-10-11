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
using System.Web;
using System.IO;

namespace WpfApplication1
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string queryStr = @"[{""version"": ""0.2"",""type"": ""centerScreenView"",""centerScreenView"": {""collection"":""centerScreenAlarm""},""criteria"": {""bodySign"":""1000010001""}}]";

			//string str = @"[{""version"": ""0.2"",""type"": ""centerScreenView"",""centerScreenView"": {""collection"":""publicBodyTree""},""criteria"": {""bodySign"":""1000010001"",""bodyType"":1}}]";
			CreateUrl(queryStr);
		}

		public void CreateUrl(string queryStr)
		{
			queryStr = HttpUtility.UrlEncode(queryStr);

			string url = string.Concat("http://192.168.88.66:8888/EMS_Service_V/rest/ServiceView/qureyArrayStr/", queryStr);

			WebClient client = new WebClient();

			client.DownloadStringCompleted -= Client_DownloadStringCompleted;

			client.DownloadStringCompleted += Client_DownloadStringCompleted;

			client.DownloadStringAsync(new Uri(url), null);

		//	var request = (HttpWebRequest)HttpWebRequest.Create(url);
		//	request.Method = "GET";
		//	var response = request.GetResponse();
		//	if (response == null) return;
		//	var streamResponse = response.GetResponseStream();
		//	var reader = new StreamReader(streamResponse, Encoding.Default);
		//	var result = reader.ReadToEnd();
		}

		private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
		{
			if (e.Error != null)
				Console.WriteLine(e.Error.Message);
			else
			{
				string str = e.Result;
			}
		}
	}
}
