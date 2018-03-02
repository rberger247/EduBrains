using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EduBrain.Startup))]
namespace EduBrain
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
