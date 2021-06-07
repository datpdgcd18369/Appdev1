using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
    // GET: AT
    public class ManageUserController : Controller

    {

      ApplicationDbContext _context = new ApplicationDbContext();

      // GET: Admin/ManageUser

      [HttpGet]
      [Authorize(Roles = "Admin")]
      public ActionResult Index()

      {


        IEnumerable<ApplicationUser> model = _context.Users.AsEnumerable();

        return View(model);




      }

      [HttpGet]
      [Authorize(Roles = "Admin")]
      public ActionResult Edit(string Id)

      {

        ApplicationUser model = _context.Users.Find(Id);
      var userInfo = _context.userIfos.SingleOrDefault(u => u.UserId.Equals(model));

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


      [HttpPost]
      [Authorize(Roles = "Admin")]
      [ValidateAntiForgeryToken]

      public ActionResult EditroleFromUser(string UserId, string RoleId)

      {

        ApplicationUser model = _context.Users.Find(UserId);

        model.Roles.Remove(model.Roles.Single(m => m.RoleId == RoleId));

        _context.SaveChanges();

        ViewBag.RoleId = new SelectList(_context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");

        return RedirectToAction("EditRole", new { Id = UserId });

      }

      public ActionResult Delete(string Id)

      {

        var model = _context.Users.Find(Id);

        return View(model);

      }

      [HttpPost]
      [Authorize(Roles = "Admin")]
      [ValidateAntiForgeryToken]

      [ActionName("Delete")]

      public ActionResult DeleteConfirmed(string Id)

      {

        ApplicationUser model = null;

        try

        {

          model = _context.Users.Find(Id);

          _context.Users.Remove(model);

          _context.SaveChanges();

          return RedirectToAction("Index");

        }

        catch (Exception ex)

        {

          ModelState.AddModelError("", ex.Message);

          return View("Delete", model);

        }

      }

    }
  }
