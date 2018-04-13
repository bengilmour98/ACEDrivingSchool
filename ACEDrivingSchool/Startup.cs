using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACEDrivingSchool.Startup))]
namespace ACEDrivingSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
