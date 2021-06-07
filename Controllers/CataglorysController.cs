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
    public class CataglorysController : Controller
    {
        // GET: Cataglory
        private ApplicationDbContext _context; // use ApplicationDbContext class to connect to database

        public CataglorysController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var cataglory = _context.cataglories.ToList();
            return View(cataglory);
        }
        

        [HttpGet]
        
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cataglory cataglory)
        {
            if(!ModelState.IsValid)
            {
                return View(cataglory); 
            }
            var newcataglory= new Cataglory()
            {
                Description = cataglory.Description,
                Name = cataglory.Name,
                
            };
            _context.cataglories.Add(newcataglory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var cataglory = _context.cataglories
                .SingleOrDefault(t => t.Id == id);
            if (cataglory == null) return HttpNotFound();

            _context.cataglories.Remove(cataglory);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

           

            var cataglorYInDb = _context.cataglories
                .SingleOrDefault(t => t.Id == id);

            if (cataglorYInDb == null) return HttpNotFound();

            return View(cataglorYInDb);
        }

        [HttpPost]
        public ActionResult Edit(Cataglory cataglory)
        {
            if (!ModelState.IsValid)
            {
                
                return View(cataglory);
            }


            var todoInDb = _context.cataglories
                .SingleOrDefault(t => t.Id == cataglory.Id);

            if (todoInDb == null) return HttpNotFound();

            todoInDb.Description = cataglory.Description;
            todoInDb.Name = cataglory.Name;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    [HttpGet]
    public ActionResult CheckCourse(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
      var checkCourse = _context.works
         .Where(t => t.CatagloryId == id)
         .Include(t => t.Courses)
         .Select(t => t.CourseId);
      ViewBag.CatagloryId = id;
      return View(checkCourse);
    }

    [HttpGet]
    public ActionResult AddCourse(int? id)
    {
      if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      if (_context.cataglories.SingleOrDefault(t => t.Id == id) == null)
        return HttpNotFound();

      var CourseInDb = _context.courses.ToList();
      var usersInTeam = _context.works         // User trong Team
         .Include(t => t.Courses)
         .Where(t => t.CourseId == id)
         .Select(t => t.User)
         .ToList();

      var viewModel = new CateloryCreateViewmodel()
      {
        CateloryId = (int)id,
        course = CourseInDb
      };
      return View(viewModel);
    }
    [HttpPost]
    public ActionResult AddMembers(work model)
    {
      var newwork = new work
      {
        CourseId = model.CourseId,
        CatagloryId = model.CatagloryId
      };

      _context.works.Add(newwork);
      _context.SaveChanges();

      return RedirectToAction("Members", new { id = model.CatagloryId });
    }
    [HttpGet]
    public ActionResult RemoveMember(int id, int courseid)
    {
      var teamUserToRemove = _context.works
        .SingleOrDefault(t => t.CatagloryId == id && t.CourseId == courseid);

      if (teamUserToRemove == null)
        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

      _context.works.Remove(teamUserToRemove);
      _context.SaveChanges();
      return RedirectToAction("Members", new { id = id });
    }
  }
}