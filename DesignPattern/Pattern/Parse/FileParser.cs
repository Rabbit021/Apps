using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Parse
{
	public class FileParser : GeneralParser
	{
		protected override void Load()
		{
			Console.WriteLine("Load the data from file");
		}

		protected override void Parse()
		{
			Console.WriteLine("Parase the file data");
		}
	}
}
