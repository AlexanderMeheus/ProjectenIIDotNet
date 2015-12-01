using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectenIIDotNet.Startup))]
namespace ProjectenIIDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
