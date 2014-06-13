using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WcfClient.ServiceReference1;

namespace WcfClient
{
	class Program
	{
		static void Main(string[] args)
		{
			UserClient client = new UserClient();
			string result = client.ShowName("this.test");
			Console.WriteLine(result);

			double f = 20.268;
			var str = f.Round2<double>();
			Console.WriteLine(str);
			Console.ReadKey();
		}
	}

	public static class DataRound
	{
		public static string Round2<T>(this T input)
		{
			return input.ToString();
		}
	}
}
