using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pattern.Parse
{
	public abstract class GeneralParser
	{
		protected abstract void Load();
		protected abstract void Parse();
		protected virtual void Dump()
		{
			Console.WriteLine("Dump data into Database");
		}

		public void Process()
		{
			Load();
			Parse();
			Dump();
		}
	}
}
