using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SalaryCalculatorWeb.Startup))]
namespace SalaryCalculatorWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
