using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudIS.Web.Mvc.Startup))]
namespace StudIS.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
