using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADLRecorderApp.Startup))]
namespace ADLRecorderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
