using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XLookupReportSystem.Startup))]
namespace XLookupReportSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
