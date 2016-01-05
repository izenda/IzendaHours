using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Izenda.AdHoc;
using System.Text;
using System.Web.UI.WebControls;
using System.Reflection;

namespace IzendaHours.Controllers {
  public class ReportingController : Controller {

    [Authorize]
    [ValidateInput(false)]
    public ActionResult ReportDesigner() {
        

      return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult ReportList() {


      //if (HttpContext.Request != null && !String.IsNullOrEmpty(HttpContext.Request.RawUrl) && !HttpContext.Request.RawUrl.ToLower().Contains(AdHocSettings.ReportList.ToLower())) {
      //  return RedirectToAction("ReportList", "Reporting");
      //}
      return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult Settings() {
      return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult InstantReportNew()
    {
        return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult Dash()
    {
        return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult Dashboards() {


      return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult ReportViewer() {


      AdHocSettings.ShowSimpleModeViewer = true;
      return View();
    }

    [Authorize]
    [ValidateInput(false)]
    public ActionResult InstantReport() {


      return View();
    }

    [Authorize]  
    [ValidateInput(false)]
    public ActionResult DashboardDesigner() {


      return View();
    }
  }
}
