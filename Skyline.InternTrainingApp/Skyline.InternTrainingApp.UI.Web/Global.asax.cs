using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Skyline.InternTrainingApp.UI.Web.Utility;
using StructureMap;

namespace Skyline.InternTrainingApp.UI.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WireUpDependencyInjection();
            SetControllerFactory();
        }

        /// <summary>
        /// Wire up our dependency's with StructureMap
        /// We are using StructureMap's scanning and
        /// convention over configuration abilities here.
        /// Basically StructureMap scans every directory
        /// when it finds an Interface (ex. IFoo) it looks
        /// for a corresponding class named "Foo" based on then
        /// naming convention that concreted implementations of
        /// a class are named exactly the same as there interface
        /// minus the leading "I"
        /// </summary>
        private void WireUpDependencyInjection()
        {
            ObjectFactory.Initialize(registry => registry.Scan(x =>
            {
                x.AssembliesFromApplicationBaseDirectory();
                x.WithDefaultConventions();
            }));
        }

        /// <summary>
        /// Sets the controller factory to our custom
        /// controller factory that uses StructureMap
        /// for dependency resolution
        /// </summary>
        private void SetControllerFactory() {
            ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());
        }
    }
}