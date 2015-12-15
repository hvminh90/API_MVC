using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_MVC.Startup))]
namespace Project_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
