using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using Application.Core.Entitys;

namespace Application.DAL.Mapping
{
	public class UserInfoMapping : EntityTypeConfiguration<UserInfo>
	{
		public UserInfoMapping()
		{
			this.HasKey(x => x.Id);
			this.ToTable("UserInfo");
		}
	}
}
