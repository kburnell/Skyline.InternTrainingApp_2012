using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Skyline.InternTrainingApp.UI.Web.Utility {

    /// <summary>
    /// Custom controller factory that uses 
    /// StructureMap for dependency resolution
    /// </summary>
    public class ControllerFactory : DefaultControllerFactory {

        #region << Private Constants >>

        private const string ControllerNotFound = "The controller for path '{0}' could not be found or it does not implement IController.";
        private const string NotAController = "Type requested is not a controller: {0}";
        private const string UnableToResolveController = "Unable to resolver controller: {0}"; 

        #endregion

        #region << Constructors >>

        public ControllerFactory() {
            Container = ObjectFactory.Container;
        } 

        #endregion

        #region << Public Properties >>

        public IContainer Container { get; set; } 

        #endregion

        #region << Public/Protected Methods >>

        protected override IController GetControllerInstance(RequestContext context, Type controllerType) {
            IController controller;
            if (controllerType == null)
                throw new HttpException(404, String.Format(ControllerNotFound, context.HttpContext.Request.Path));
            if (!typeof (IController).IsAssignableFrom(controllerType))
                throw new ArgumentException(string.Format(NotAController, controllerType.Name), "controllerType");
            try {
                controller = Container.GetInstance(controllerType) as IController;
            }
            catch (Exception ex) {
                throw new InvalidOperationException(String.Format(UnableToResolveController, controllerType.Name), ex);
            }
            return controller;
        } 

        #endregion
    }
}