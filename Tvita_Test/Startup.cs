using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tvita_Test.Startup))]
namespace Tvita_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
