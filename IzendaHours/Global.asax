<%@ Application Codebehind="Global.asax.cs" Inherits="IzendaHours.MvcApplication" Language="C#" %>
<%@ Import Namespace="Izenda.AdHoc"%>
<%@Import Namespace="Izenda.AdHoc.Database"%>
<%@ Import Namespace="Izenda.Fusion"%>
<%@ Import Namespace="System.IO"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Drawing" %>

<script RunAt="server">
    void Application_AcquireRequestState(object sender, EventArgs e) {
    CustomAdHocConfig.InitializeReporting();
    }

    [Serializable]
    public class CustomAdHocConfig : DatabaseAdHocConfig 
    {
        public static void InitializeReporting()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["ReportingInitialized"] != null)
                return;
            AdHocSettings.LicenseKey = "INSERT_LICENSE_KEY_HERE";
            AdHocSettings.SqlServerConnectionString = @"INSERT_CONNECTION_STRING_HERE";
            AdHocSettings.GenerateThumbnails = true;
            AdHocSettings.ShowSimpleModeViewer = true;
            AdHocSettings.IdentifiersRegex = "^.*[iI][Dd]$";
            AdHocSettings.TabsCssUrl = "/Resources/css/tabs.css";
            AdHocSettings.ReportCssUrl = "/Resources/css/Report.css";
            AdHocSettings.ShowBetweenDateCalendar = true;
            AdHocSettings.DashboardViewer = "ReportViewer";
            AdHocSettings.ReportViewer = "ReportViewer";
            AdHocSettings.InstantReport = "InstantReport";
            AdHocSettings.ReportDesignerUrl = "ReportDesigner";
            AdHocSettings.DashboardDesignerUrl = "DashboardDesigner";
            AdHocSettings.ReportList = "ReportList";
            AdHocSettings.SettingsPageUrl = "Settings";
            AdHocSettings.ParentSettingsUrl = "Settings";
            AdHocSettings.ResponseServer = "rs.aspx";
            AdHocSettings.ShowSqlEditor = true;
            AdHocSettings.VisibleDataSources = new string[] { "Projects", "Records", "Tasks" };
            AdHocSettings.ReportsPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "Reports");
            AdHocSettings.PrintMode = PrintMode.Html2PdfAndHtml;
            AdHocSettings.ChartingEngine = ChartingEngine.HtmlChart;
            AdHocSettings.AdHocConfig = new CustomAdHocConfig();
            HttpContext.Current.Session["ReportingInitialized"] = true;
        }
    }
</script>
