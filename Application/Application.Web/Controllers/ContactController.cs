using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Manager.Implementation;
using Application.DTO.ProfileModule;
using System.Net;

namespace Application.Web.Controllers
{
	public class ContactController : Controller
	{
		[HttpPost]
		public JsonResult GetAllProfiles()
		{
			var profiles = ContactManager.Instance.FindAllProfiles();
			return Json(profiles);
		}

		[HttpPost]
		public JsonResult GetProfileById(int id)
		{
			var profile = ContactManager.Instance.FindProfileById(id);
			return Json(profile);
		}

		[HttpPost]
		public HttpStatusCodeResult SaveProfileInformation(ProfileDTO profileDTO)
		{
			ContactManager.Instance.SaveProfileInformation(profileDTO);
			return new HttpStatusCodeResult(HttpStatusCode.OK);
		}

		[HttpPost]
		public HttpStatusCodeResult UpdayeProfileInformation(int id, ProfileDTO profileDTO)
		{
			ContactManager.Instance.UppdateProfileInformation(id, profileDTO);
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
