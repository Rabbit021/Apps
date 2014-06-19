using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UnitOfWork.Models
{
	public interface IArticleRepository
	{
		IEnumerable<Article> GetAll();
		Article Add(Article item);
		void Update(Article item);
		void Delete(Article item);
		Article Get(Guid id);
	}

	public class ArticleRepository : IArticleRepository
	{
		private readonly WebDbContext _context;
		public WebDbContext Context
		{
			get { return _context; }
		}

		public ArticleRepository(IWeDbbContext context)
		{
			this._context = context as WebDbContext;
		}

		public IEnumerable<Article> GetAll()
		{
			return this.Context.Articles;
		}

		public Article Add(Article item)
		{
			this.Context.Articles.Add(item);
			return item;
		}

		public void Update(Article item)
		{
			if (this.Context.Articles.Local.Select(x => string.Equals(x.Id, item.Id)).Any())
				throw new ApplicationException("exists");
			this.Context.Entry(item).State = EntityState.Modified;
		}

		public void Delete(Article item)
		{
			if (this.Context.Articles.Local.Select(x => string.Equals(x.Id, item.Id)).Any())
				throw new ApplicationException("exists");
			this.Context.Entry(item).State = EntityState.Deleted;
		}

		public Article Get(Guid id)
		{
			return this.Context.Articles.FirstOrDefault(x => string.Equals(x.Id, id));
		}
	}
}