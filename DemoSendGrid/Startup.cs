using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoSendGrid.Startup))]
namespace DemoSendGrid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
