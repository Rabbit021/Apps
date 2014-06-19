using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Parse
{
	public class SqlServerParse : GeneralParser
	{

		protected override void Load()
		{
			Console.WriteLine("Connect to Sql Server ");
		}

		protected override void Parse()
		{
			Console.WriteLine("Loop through the dataset");
		}
	}
}
