namespace IzendaHours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.IO;
    using Izenda.AdHoc;
    using Izenda.Fusion;
    using Izenda.AdHoc.Database;

    [Serializable]
    public class CustomAdHocConfig : DatabaseAdHocConfig
    {
        public static void InitializeReporting()
        {
            if (HttpContext.Current.Session == null || HttpContext.Current.Session["ReportingInitialized"] != null)
                return;
            AdHocSettings.LicenseKey = "IZENDA_LICENSE_KEY";
            AdHocSettings.AdHocConfig = new CustomAdHocConfig();
            AdHocSettings.SqlServerConnectionString = @"SQL_SERVER_CONNECTION_STRING";
            
            AdHocSettings.GenerateThumbnails = true;
            AdHocSettings.ShowSimpleModeViewer = true;
            AdHocSettings.IdentifiersRegex = "^.*[iI][Dd]$";
            AdHocSettings.TabsCssUrl = "/Resources/css/tabs.css";
            AdHocSettings.ReportCssUrl = "/Resources/css/Report.css";
            AdHocSettings.ShowBetweenDateCalendar = true;
            AdHocSettings.DashboardViewer = "Dash";
            AdHocSettings.ReportViewer = "ReportViewer";
            AdHocSettings.InstantReport = "InstantReport";
            AdHocSettings.ReportDesignerUrl = "ReportDesigner";
            AdHocSettings.DashboardDesignerUrl = "Dash";
            AdHocSettings.InstantReport = "InstantReportNew";
            AdHocSettings.ReportList = "ReportList";
            AdHocSettings.SettingsPageUrl = "Settings";
            AdHocSettings.ParentSettingsUrl = "Settings";
            AdHocSettings.ResponseServer = "rs.aspx";
            AdHocSettings.ShowSqlEditor = true;
            AdHocSettings.ShowJoinAliasTextboxes = true;
            AdHocSettings.ShowJoinDropDown = true;
            AdHocSettings.ShowAdditionalJoinConditions = true;
            AdHocSettings.EvoAzureServiceConfig = new EvoPdfAzureCloudServiceConfig("127.0.0.1", 40001, "password"); 
            AdHocSettings.PdfPrintMode = PdfMode.EvoPdfAzureCloudService;
            AdHocSettings.ChartingEngine = ChartingEngine.HtmlChart;
            HttpContext.Current.Session["ReportingInitialized"] = true;
        }
    }
}