using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace UnitOfWork.Models
{
	public class ArticleMapping : EntityTypeConfiguration<Article>
	{
		public ArticleMapping()
		{
			this.HasKey(x => x.Id);
			this.ToTable("Articles");
		}
	}
}