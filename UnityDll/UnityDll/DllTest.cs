using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityDll
{
	public class DllTest
	{
		public int c;

		public void AddValues(int a, int b)
		{
			c = a + b;
		}
	}
}
