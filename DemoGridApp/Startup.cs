using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoGridApp.Startup))]
namespace DemoGridApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
