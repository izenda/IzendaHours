<%@ Application Codebehind="Global.asax.cs" Inherits="IzendaHours.MvcApplication" Language="C#" %>

<script RunAt="server">
    void Application_AcquireRequestState(object sender, EventArgs e) {
    IzendaHours.CustomAdHocConfig.InitializeReporting();
    }
</script>
