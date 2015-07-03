using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using IzendaHours.Models;
using Izenda.AdHoc;

namespace IzendaHours.Controllers
{
    public class RecordsController : Controller
    {
        private IzendaHoursEntities db = new IzendaHoursEntities();

        // GET: Records
        [Authorize]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.GetUserName();
                var name = email.Split('.');
                var firstName = name[0];
                var records = db.Records.Include(r => r.Project).Include(r => r.Task);
                if (User.Identity.GetUserName() == "admin")
                {
                   return View(records.ToList());
                }
                return View(records.ToList().Where(user => user.EmployeeId.Contains(firstName.First().ToString().ToUpper() + firstName.Substring(1))));
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // GET: Records/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        [Authorize]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.ProjectId = new SelectList(db.Projects.OrderBy(model => model.Project1), "ProjectId", "Project1");
                ViewBag.TaskId = new SelectList(db.Tasks, "TaskId", "Task1");
                return View();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryId,EmployeeId,TaskId,CaseNo,ProjectId,Hours,WikiLink,Notes,RecordDate")] Record record)
        {
            if (ModelState.IsValid)
            {
                var email = User.Identity.GetUserName();
                var name = email.Split('.');
                var firstName = name[0];
                record.EmployeeId = firstName.First().ToString().ToUpper() + firstName.Substring(1);
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Project1", record.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "TaskId", "Task1", record.TaskId);
            return View(record);
        }

        // GET: Records/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProjectId = new SelectList(db.Projects.OrderBy(model => model.Project1), "ProjectId", "Project1", record.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "TaskId", "Task1", record.TaskId);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryId,EmployeeId,TaskId,CaseNo,ProjectId,Hours,WikiLink,Notes,RecordDate")] Record record)
        {
            var email = User.Identity.GetUserName();
            var name = email.Split('.');
            var firstName = name[0];

            if (ModelState.IsValid)
            {
                record.EmployeeId = firstName.First().ToString().ToUpper() + firstName.Substring(1);
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Project1", record.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "TaskId", "Task1", record.TaskId);
            return View(record);
        }

        // GET: Records/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Reporting
        [Authorize]
        public ActionResult Reporting()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Welcome()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
