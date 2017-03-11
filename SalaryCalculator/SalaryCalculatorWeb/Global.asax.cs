using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using SalaryCalculatorWeb.App_Start;
using SalaryCalculator.Configuration.Mappings;
using System.Reflection;

namespace SalaryCalculatorWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbConfig.Initialize();
            var autoMapperConfig = new AutoMapperConfiguration();
            autoMapperConfig.Config(Assembly.GetExecutingAssembly());
        }
    }
}
