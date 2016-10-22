using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PastebookUILayer.Startup))]
namespace PastebookUILayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
