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
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context; // use ApplicationDbContext class to connect to database

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
    // GET: Courses

    public ActionResult Index()
    {
      var courses = _context.courses.ToList();
      return View(courses);
    }


    [HttpGet]

    public ActionResult Create()
    {

      return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Course course)
    {
      if (!ModelState.IsValid)
      {
        return View(course);
      }
      var newourse = new Course()
      {

        Description = course.Description,
        Name = course.Name,
        StartDateTime = course.StartDateTime,
        EndDateTime =course.EndDateTime
      };
      
      _context.courses.Add(newourse);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }
    public ActionResult Delete(int? id)
    {
      if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var courseInDb = _context.courses
          .SingleOrDefault(t => t.Id == id);
      if (courseInDb == null) return HttpNotFound();

      _context.courses.Remove(courseInDb);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpGet]
    public ActionResult Edit(int? id)
    {
      if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var courseInDb = _context.courses
          .SingleOrDefault(t => t.Id == id);

      if (courseInDb == null) return HttpNotFound();

      return View(courseInDb);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      if (!ModelState.IsValid)
      {
        return View(course);
      }
      var courseInDb = _context.courses
          .SingleOrDefault(t => t.Id == course.Id);

      if (courseInDb == null) return HttpNotFound();

      courseInDb.Description = course.Description;
      courseInDb.Name = course.Name;
      courseInDb.StartDateTime = course.StartDateTime;
      courseInDb.EndDateTime = course.EndDateTime;

      _context.SaveChanges();

      return RedirectToAction("Index");
    }
    
    public ActionResult Detail(int? id)
    {
      if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var courseInDb = _context.toppics.Where(m => m.CourseId == id).ToList();
      if (courseInDb == null) return HttpNotFound();
      return View(courseInDb);
    }


    
  }
}