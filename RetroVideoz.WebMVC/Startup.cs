using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RetroVideoz.WebMVC.Startup))]
namespace RetroVideoz.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
