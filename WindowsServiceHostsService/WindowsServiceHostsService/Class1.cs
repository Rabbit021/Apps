using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WindowsServiceHostsService
{
	[ServiceContract]
	public interface ISimpleCalculator
	{
		[OperationContract]
		int Add(int num1, int num2);

		[OperationContract]
		[OperationBehavior(ReleaseInstanceMode = ReleaseInstanceMode.BeforeCall)]
		int Subtract(int num1, int num2);
	}
}
