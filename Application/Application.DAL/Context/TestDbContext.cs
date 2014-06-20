using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Application.Core.Entitys;
using Application.DAL.Mapping;

namespace Application.DAL.Context
{
	public class TestDbContext : DbContext, IContext
	{
		public DbSet<UserInfo> UserInfos { get; set; }
		public DbSet<PersonalEvent> PersonalEvents { get; set; }

		public TestDbContext() :
			base("name=connectionStr")
		{
			Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserInfoMapping());
			modelBuilder.Configurations.Add(new PesonalEventMapping());
			base.OnModelCreating(modelBuilder);
		}
	}
}
