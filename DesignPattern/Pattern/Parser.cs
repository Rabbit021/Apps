using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pattern.Parse;

namespace Pattern
{
	public class Parser
	{
		private GeneralParser parser = new SqlServerParse();
		public GeneralParser Instance { get { return parser; } }
		public Parser(GeneralParser parser)
		{
			if (parser != null)
				this.parser = parser;
		}
	}
}
