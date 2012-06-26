using StructureMap;

namespace Skyline.InternTrainingApp.Common.Utility
{
    public static class DependencyResolver
    {
        #region << Public Methods >>

        public static T GetConcreteInstanceOf<T>()
        {
            return ObjectFactory.GetInstance<T>();
        }

        #endregion
    }
}
