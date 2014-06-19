using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
	//public class Singleton
	//{
	//	//lazy Init
	//	private static Singleton instance = null;
	//	private Singleton() { }
	//	public static Singleton Instance
	//	{
	//		get
	//		{
	//			if (instance == null)
	//				instance = new Singleton();
	//			return instance;
	//		}
	//	}
	//}

	public class ApplicationState
	{
		private static ApplicationState instance = null;
		private ApplicationState() { }
		private static object lockthis = new object();
		public static ApplicationState Instance
		{
			get
			{
				lock (lockthis)
				{
					if (ApplicationState.instance == null)
						instance = new ApplicationState();
					return instance;
				}
			}
		}

		public string LoginId { get; set; }
		public string RoleId { get; set; }
	}
}
