using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
		// GET: Userifo
		[Authorize]
		public class UserifoController : Controller
		{
			private ApplicationDbContext _context;
			public UserifoController()
			{
				_context = new ApplicationDbContext();
			}
			// GET: UserInfos
			public ActionResult Index()
			{
				var userId = User.Identity.GetUserId();
				var userInfo = _context.userIfos.SingleOrDefault(u => u.UserId.Equals(userId));

				if (userInfo == null) return HttpNotFound();

				return View(userInfo);
			}
		[HttpGet]
		public ActionResult Edit()
		{
			var userId = User.Identity.GetUserId();
			var userInfo = _context.userIfos.SingleOrDefault(u => u.UserId.Equals(userId));

			if (userInfo == null) return HttpNotFound();

			return View(userInfo);
		}

		[HttpPost]
		public ActionResult Edit(UserIfo userInfo)
		{
			var userInfoInDb = _context.userIfos.SingleOrDefault(u => u.UserId.Equals(userInfo.UserId));

			if (userInfo == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			userInfoInDb.FullName = userInfo.FullName;
			userInfoInDb.Age = userInfo.Age;
			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}