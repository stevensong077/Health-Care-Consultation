using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week8LoginDemo.Startup))]
namespace Week8LoginDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
