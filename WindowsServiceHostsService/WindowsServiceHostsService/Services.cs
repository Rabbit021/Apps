using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WindowsServiceHostsService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
	public class SimpleCalculator : ISimpleCalculator
	{
		static int count = 0;
		public int Add(int num1, int num2)
		{
			count++;
			Console.WriteLine(count);
			return num1 + num2;
		}

		public int Subtract(int num1, int num2)
		{
			return num1 - num2;
		}
	}
}
