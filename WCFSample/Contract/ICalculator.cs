using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Contract
{
	[ServiceContract(Namespace = "CalculatorService")]
	public interface ICalculator
	{
		[OperationContract]
		double Add(double x, double y);
	}
}
