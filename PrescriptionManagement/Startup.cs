using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrescriptionManagement.Startup))]
namespace PrescriptionManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
