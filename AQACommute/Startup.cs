using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AQACommute.Startup))]
namespace AQACommute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
