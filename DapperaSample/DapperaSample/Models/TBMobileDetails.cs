using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperaSample.Models
{
	public class TBMobileDetails
	{
		private int _mobileID;
		public int MobileID
		{
			get { return _mobileID; }
			set { _mobileID = value; }
		}

		private string _mobileName;
		public string MobileName
		{
			get { return _mobileName; }
			set { _mobileName = value; }
		}

		private string _mobileIMEno;
		public string MobileIMEno
		{
			get { return _mobileIMEno; }
			set { _mobileIMEno = value; }
		}

		private string _mobileMannfactured;
		public string MobileMannfactured
		{
			get { return _mobileMannfactured; }
			set { _mobileMannfactured = value; }
		}

		private decimal _mobileprice;

		public decimal Mobileprice
		{
			get { return _mobileprice; }
			set { _mobileprice = value; }
		}
	}
}