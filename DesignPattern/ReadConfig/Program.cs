using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ReadConfig
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	[XmlRoot(Namespace = "urn:com:company:project:v1")]
	public class StateProvinceData
	{
		[XmlElement("Country")]
		public Country[] Countries { get; set; }
	}

	[XmlRoot(Namespace = "urn:com:company:project:v1")]
	public class Country
	{
		[XmlAttribute("locale")]
		public string Loacle { get; set; }

		[XmlIgnore]
		public string Name
		{
			get { return string.Empty; }
		}
		[XmlAttribute("hasStateProvinces")]
		public bool HasStateProvinces { get; set; }

		[XmlAttribute("isPostalCodeRequired")]
		public bool IsPostalCodeRequired { get; set; }

		[XmlAttribute("phonePrefix")]
		public string PhonePrefix { get; set; }

		[XmlElement("StateProvince")]
		public StateProvince[] StateProvinces { get; set; }
	}

	[XmlRoot(Namespace = "urn:com:company:project:v1")]
	public class StateProvince
	{
		[XmlAttribute("value")]
		public string Value;

		[XmlText]
		public string Text;
	}

	public static class StateProvinceTable
	{
	}
}
