using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Core;
using System.Data.Entity;
using System.Data;
using Application.DAL.Context;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Application.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Context
		private readonly TestDbContext _context;

		public TestDbContext Context
		{
			get { return _context; }
		}

		#endregion

		#region Transaction
		private readonly IDbTransaction _transaction;

		public IDbTransaction Transaction
		{
			get { return _transaction; }
		}
		#endregion

		#region ObjectContext
		private readonly ObjectContext _objectContext;
		public ObjectContext ObjectContext
		{
			get { return _objectContext; }
		}
		#endregion

		public UnitOfWork(IContext context)
		{
			this._context = context as TestDbContext;
			this._objectContext = ((IObjectContextAdapter)this.Context).ObjectContext;
			if (this.ObjectContext.Connection.State != ConnectionState.Open)
			{
				this.ObjectContext.Connection.Open();
				this._transaction = this.ObjectContext.Connection.BeginTransaction();
			}
		}

		public void Commit()
		{
			try
			{
				this.Context.SaveChanges();
				this.Transaction.Commit();
			}
			catch
			{
				RoolBack();
				throw;
			}
		}

		public void RoolBack()
		{
			this.Transaction.Rollback();
			foreach (var entry in this.Context.ChangeTracker.Entries())
			{
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.State = EntityState.Unchanged;
						break;
					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;
					case EntityState.Deleted:
						entry.State = EntityState.Unchanged;
						break;
				}
			}
		}

		public void Dispose()
		{
			if (this.ObjectContext.Connection.State == ConnectionState.Open)
				this.ObjectContext.Connection.Close();
		}
	}
}
