using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Core.Entitys
{
	public class PersonalEvent : EntityBase
	{
		public string Description { get; set; }
		public string Title { get; set; }
		public string Where { get; set; }
		public string When { get; set; }
	}
}
