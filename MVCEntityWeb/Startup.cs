using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEntityWeb.Startup))]
namespace MVCEntityWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
