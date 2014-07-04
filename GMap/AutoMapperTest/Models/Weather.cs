using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapperTest.ServiceReferenceWeather;
using System.Windows;

namespace AutoMapperTest.Models
{
	public class Weather
	{
		#region Instance
		private static Weather instance = new Weather();
		public static Weather Instance { get { return instance; } }
		private Weather()
		{
			client = new WeatherWSSoapClient("WeatherWSSoap");
		}
		#endregion

		WeatherWSSoapClient client;

		public void GetWeather(string name)
		{
			client.getWeatherCompleted -= Client_getWeatherCompleted;
			client.getWeatherCompleted += Client_getWeatherCompleted;
			client.getWeatherAsync(name, "");
		}
		public event RoutedEventHandler GetWeatherCommplete = (sender, e) => { };
		private void Client_getWeatherCompleted(object sender, getWeatherCompletedEventArgs e)
		{
			if (e.Result == null) return;
			WeatherData res = new WeatherData();
			try
			{
				res = new WeatherData
				{
					WeatherStr = e.Result[7],
					WeatherImage = string.Format("/Images/weather/a_{0}", e.Result[10])
				};
			}
			catch
			{
				res = new WeatherData { WeatherStr = "暂无数据", WeatherImage = "/Images/weather/a_nothing.gif" };
			}
			GetWeatherCommplete(this, res);
		}
	}

	public class WeatherData : RoutedEventArgs
	{
		public string WeatherStr { get; set; }
		public string WeatherImage { get; set; }
	}
}
