using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IzendaHours.Startup))]
namespace IzendaHours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
