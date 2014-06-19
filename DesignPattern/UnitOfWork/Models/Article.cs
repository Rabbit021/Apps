using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitOfWork.Models
{
	public class Article
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string ArticleContent { get; set; }
		public int ViewCount { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public string CreatedByUserName { get; set; }
		public string Tags { get; set; }
	}
}