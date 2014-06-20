using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Manager.Implementation;
using Application.DTO.ProfileModule;
using System.Net;
using Application.Manager.Contract;
using Castle.Core.Logging;

namespace Application.Web.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactManager manager;
		public IContactManager Manager
		{
			get { return manager; }
		}

		public ILogger Logger { get; set; }

		public ContactController(IContactManager manager)
		{
			this.manager = manager;
		}

		[HttpPost]
		public JsonResult GetAllProfiles()
		{
			var profiles = this.Manager.FindAllProfiles();
			if (profiles.Any())
				Logger.WarnFormat("");
			return Json(profiles);
		}

		[HttpPost]
		public JsonResult GetProfileById(int id)
		{
			var profile = this.Manager.FindProfileById(id);
			return Json(profile);
		}

		[HttpPost]
		public HttpStatusCodeResult SaveProfileInformation(ProfileDTO profileDTO)
		{
			this.Manager.SaveProfileInformation(profileDTO);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		[HttpPost]
		public HttpStatusCodeResult UpdayeProfileInformation(int id, ProfileDTO profileDTO)
		{
			this.Manager.UppdateProfileInformation(id, profileDTO);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CreateEdit()
		{
			return View();
		}

	}
}
