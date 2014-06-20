using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitOfWork.Models;

namespace UnitOfWork.Controllers
{
	public class BaseController : Controller
	{
		private readonly IUnitOfworkManager manager;
		public IUnitOfworkManager Manager
		{
			get { return manager; }
		}

		public BaseController(IUnitOfworkManager unit)
		{
			this.manager = unit;
		}
	}
}
