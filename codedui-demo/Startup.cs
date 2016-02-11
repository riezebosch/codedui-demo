using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(codedui_demo.Startup))]
namespace codedui_demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
