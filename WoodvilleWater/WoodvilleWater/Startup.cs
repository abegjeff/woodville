using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoodvilleWater.Startup))]
namespace WoodvilleWater
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
