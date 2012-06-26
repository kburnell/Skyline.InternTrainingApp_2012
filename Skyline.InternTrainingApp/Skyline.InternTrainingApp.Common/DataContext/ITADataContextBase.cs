using System.Data.Entity;
using Skyline.InternTrainingApp.Common.Domain;

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

        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        #endregion

    }
}