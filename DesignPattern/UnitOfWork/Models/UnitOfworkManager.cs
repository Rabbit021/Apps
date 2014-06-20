using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnitOfWork.Models
{
	public interface IUnitOfworkManager : IDisposable
	{
		IUnitOfWork NewUnitOfWork();
	}

	public class UnitOfworkManager : IUnitOfworkManager
	{
		private bool _isDispose;
		public bool IsDispose
		{
			get { return _isDispose; }
			set { _isDispose = value; }
		}

		#region Context
		private readonly WebDbContext _context;
		public WebDbContext Context
		{
			get { return _context; }
		}
		#endregion

		public UnitOfworkManager(IWeDbbContext context)
		{
			Database.SetInitializer<WebDbContext>(null);
			this._context = context as WebDbContext;
		}

		public IUnitOfWork NewUnitOfWork()
		{
			return new UnitOfWork(this.Context);
		}


		public void Dispose()
		{
			if (!this.IsDispose)
			{
				this.Context.Dispose();
				this.IsDispose = true;
			}
		}
	}
}