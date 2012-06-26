using System.Data.Entity;

namespace Skyline.InternTrainingApp.Common.DataContext {

    /// <summary>
    /// Abstract base class for the applications
    /// Entity Framework Data Context
    /// </summary>
    public abstract class ITADataContextBase : DbContext {

        #region << Constructors >>

        protected ITADataContextBase(string nameOrConnectionString) : base(nameOrConnectionString) {} 
        
        #endregion

        #region << Public Properties >>

         

        #endregion

    }
}