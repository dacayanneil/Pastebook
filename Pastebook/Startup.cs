using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pastebook.Startup))]
namespace Pastebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
