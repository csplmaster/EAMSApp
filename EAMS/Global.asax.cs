using EAMS.Mapper_Profile;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EAMS.CustomFilters;

namespace EAMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EAMSAutomapWebProfile.Run();
            GlobalFilters.Filters.Add(new CSPLErrorHandler());
            //Make hanges
            //Ihave made chgs
            //Changes Done by ajay
        }
    }
}
