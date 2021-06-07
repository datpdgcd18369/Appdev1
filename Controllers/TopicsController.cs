using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.viewmodel;

namespace WebApplication1.Controllers
{
	public class TopicsController : Controller
	{
		// GET: Topics
		private ApplicationDbContext _context; // use ApplicationDbContext class to connect to database

		public TopicsController()
		{
			_context = new ApplicationDbContext();
		}
		// GET: Courses

		public ActionResult Index()
		{
			var Topic = _context.toppics.Include(m => m.Course).ToList();
			return View(Topic);
		}


		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new ToppicCourseViewmodel()
			{
				Courses = _context.courses.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Toppic toppic)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new ToppicCourseViewmodel()
				{
					Toppic = toppic,
					Courses = _context.courses.ToList()
				};
				return View(viewModel);
			}

			var newToppic = new Toppic()
			{
				Description = toppic.Description,
				Name = toppic.Name,
				CourseId = toppic.CourseId
			};

			_context.toppics.Add(newToppic);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


			var toppicInDb = _context.toppics
				.SingleOrDefault(t => t.Id == id);

			if (toppicInDb == null) return HttpNotFound();

			var viewModel = new ToppicCourseViewmodel()
			{
				Toppic = toppicInDb,
				Courses = _context.courses.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(Toppic toppic)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new ToppicCourseViewmodel()
				{
					Toppic = toppic,
					Courses = _context.courses.ToList()
				};
				return View(viewModel);
			}


			var toppicInDb = _context.toppics
				.SingleOrDefault(t => t.Id == toppic.Id);
			if (toppicInDb == null) return HttpNotFound();

			toppicInDb.Description = toppic.Description;
			toppicInDb.Name = toppic.Name;
			toppicInDb.CourseId = toppic.CourseId;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
		public ActionResult Delete(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


			var todo = _context.toppics
				.SingleOrDefault(t => t.Id == id);

			if (todo == null) return HttpNotFound();

			_context.toppics.Remove(todo);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Create2(int? id)
		{
			if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var CInDb = _context.courses.Where(m => m.Id == id);


			if (CInDb == null) return HttpNotFound();

			var viewModel = new ToppicCourseViewmodel()
			{
	
				Courses = CInDb
			};
			return View(viewModel);
		}
		[HttpPost]
		public ActionResult Create2(Toppic toppic)
		{
			if (!ModelState.IsValid)
			{
				var viewModel = new ToppicCourseViewmodel()
				{
					Toppic = toppic,
					Courses = _context.courses.ToList()
				};
				return View(viewModel);
			}

			var newToppic = new Toppic()
			{
				Description = toppic.Description,
				Name = toppic.Name,
				CourseId = toppic.CourseId
			};

			_context.toppics.Add(newToppic);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

	}
}