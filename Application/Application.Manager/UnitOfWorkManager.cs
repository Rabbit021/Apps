using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Manager.Contract;
using Application.DAL.Context;
using Application.DAL;
using System.Data.Entity;
using Application.Core;

namespace Application.Manager
{
	public class UnitOfWorkManager : IUnitOfWorkManager
	{
		private readonly TestDbContext _context;
		public TestDbContext Context
		{
			get { return _context; }
		}

		public bool IsDispose { get; set; }

		public UnitOfWorkManager(IContext context)
		{
			Database.SetInitializer<TestDbContext>(null);
			this._context = context as TestDbContext;
		}

		public IUnitOfWork NewUnitOfWork()
		{
			return new UnitOfWork(this.Context);
		}
		public void Dispose()
		{
			if (this.IsDispose)
			{
				this.Context.Dispose();
				this.IsDispose = true;
			}
		}

	
	}
}
