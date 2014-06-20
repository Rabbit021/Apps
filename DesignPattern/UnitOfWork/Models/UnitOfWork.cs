using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Runtime.InteropServices;
using EntityState = System.Data.Entity.EntityState;

namespace UnitOfWork.Models
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
	}

	public class UnitOfWork : IUnitOfWork
	{
		#region Context
		private readonly WebDbContext _context;
		public WebDbContext Context
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

		public UnitOfWork(IWeDbbContext context)
		{
			this._context = context as WebDbContext;

			this._objectContext = ((IObjectContextAdapter)this.Context).ObjectContext;

			if (this._objectContext.Connection.State != ConnectionState.Open)
			{
				this._objectContext.Connection.Open();
				this._transaction = _objectContext.Connection.BeginTransaction();
			}
		}

		public void Commit()
		{
			try
			{
				this.Context.SaveChanges();
				this.Transaction.Commit();
			}
			catch (Exception)
			{
				RollBack();
				throw;
			}
		}

		private void RollBack()
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
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{

			}
		}
		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}