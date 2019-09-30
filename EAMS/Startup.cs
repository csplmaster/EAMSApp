using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EAMS.Startup))]
namespace EAMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //changed by ajay
        }
    }
}
