using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Services;
using Contract;

namespace Host
{
	class CalaulatorHost
	{
		public static void Main(string[] args)
		{
			using (var host = new ServiceHost(typeof(CalculatorService)))
			{
				host.Opened -= Host_Opened;
				host.Opened += Host_Opened;
				host.Open();
				Console.ReadKey();
			}
		}

		static void Host_Opened(object sender, EventArgs e)
		{
			Console.WriteLine("Opened");
		}
	}
}
