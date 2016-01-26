using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using IzendaHours.Models;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace IzendaHours.Controllers
{
    public class ReactController : Controller
    {
        private IzendaHoursEntities db = new IzendaHoursEntities();
        private static readonly IList<ReactView> _records; 

        // GET: React
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var email = User.Identity.GetUserName();
                var name = email.Split('.');
                var firstName = name[0];
                var records = db.ReactViews;
                var userRecords = records.ToList()
                    .Where(user => user.EmployeeId.Contains(firstName.First().ToString().ToUpper() + firstName.Substring(1)));
                
                if (User.Identity.GetUserName() == "admin")
                {
                    return View(records.ToList());
                }
                return View(userRecords);
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);

            //return View();
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ActionResult Records()
        {
            var email = User.Identity.GetUserName();
            var name = email.Split('.');
            var firstName = name[0];
            var records = db.ReactViews;
            var userRecords = records.ToList()
                .Where(user => user.EmployeeId.Contains(firstName.First().ToString().ToUpper() + firstName.Substring(1)))/*.Where(d => d.RecordDate == System.DateTime.Today)*/;
            
            return Json(userRecords, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRecord([Bind(Include = "EntryId,EmployeeId,TaskId,CaseNo,ProjectId,Hours,WikiLink,Notes,RecordDate")] Record record)
        {
            if (ModelState.IsValid)
            {
                var email = User.Identity.GetUserName();
                var name = email.Split('.');
                var firstName = name[0];
                record.EmployeeId = firstName.First().ToString().ToUpper() + firstName.Substring(1);
                db.Records.Add(record);
                db.SaveChanges();
            }
    
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Project1", record.ProjectId);
            ViewBag.TaskId = new SelectList(db.Tasks, "TaskId", "Task1", record.TaskId);
            return Content("Success! :)");
        }
    }
}