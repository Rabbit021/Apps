using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperaSample.Models;

namespace DapperaSample.Controllers
{
	public class AddMobileController : Controller
	{
		//
		// GET: /AddMobile/
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult AddMobiles()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddMobiles(TBMobileDetails mb)
		{
			MobileMain.Instance.AddMobiles(mb);
			return RedirectToAction("AllMobileList");
		}

		[HttpGet]
		public ActionResult AllMobileList()
		{
			var list = MobileMain.Instance.GetAllList();
			return View(list.ToList());
		}

		[HttpGet]
		public ActionResult Edit(string MobileID)
		{
			MobileMain.Instance.GetMobileList(MobileID);
			return View();
		}

		[HttpGet]
		public ActionResult Delete(string MobileID)
		{
			return View();
		}
	}
}
