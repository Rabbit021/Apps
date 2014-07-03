using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMap
{
	public interface IOperationFile<T> where T : class
	{
		void ReadInfo(IList<T> stus);
		void WriteInfo(IList<T> stus);
	}
}
