using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
	public class ArticleController : BaseController
	{
		private readonly IArticleRepository _articleRepository;

		public IArticleRepository ArticleRepository
		{
			get { return _articleRepository; }
		}

		public ArticleController(IUnitOfworkManager unit, IArticleRepository repos)
			: base(unit)
		{
			this._articleRepository = repos;
		}

		public ActionResult Test()
		{
			using (var unit = this.Manager.NewUnitOfWork())
			{
				this.ArticleRepository.Add(new Article
				{
					Id = Guid.NewGuid(),
					Title = "Test",
					Summary = "Summary",
					ViewCount = 10,
					ArticleContent = "Heello",
					CreatedDateTime = DateTime.Now,
					CreatedByUserName = "Admin",
					Tags = "mvc "
				});
				unit.Commit();
			}
			return View();
		}
	}
}
