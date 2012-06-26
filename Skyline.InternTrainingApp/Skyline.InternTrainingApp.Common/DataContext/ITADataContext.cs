using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Skyline.InternTrainingApp.Common.Domain;

namespace Skyline.InternTrainingApp.Common.DataContext {

    /// <summary>
    ///   Entity Framework Data Context
    /// </summary>
    public class ITADataContext : ITADataContextBase {

        #region << Constructors >>

        public ITADataContext() : base("name=InternTrainingApp") {}

        #endregion

        #region << Public/Protected Methods >>

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            //Best practice is to *NOT* have pluralized table names...why MS does it by default makes no sense!
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Cascading Deletes are the love child of Lorena Bobbit and OJ Simpson
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Unless you want the world to end in a big mushroom cloud always call the base version of the override as the last statement
            base.OnModelCreating(modelBuilder);

            ConfigurePerson(modelBuilder.Entity<Person>());
            ConfigureGenre(modelBuilder.Entity<Genre>());
            ConfigureMovie(modelBuilder.Entity<Movie>());
        }

        #endregion

        #region << Private Methods >>

        private void ConfigurePerson(EntityTypeConfiguration<Person> person) {
            person.Ignore(p => p.PersonType);
            person.Property(p => p.CreatedBy).IsRequired();
            person.Property(p => p.CreatedOn).IsRequired();
        }

        private void ConfigureGenre(EntityTypeConfiguration<Genre> genre) {
            genre.Property(p => p.CreatedBy).IsRequired();
            genre.Property(p => p.CreatedOn).IsRequired();
        }

        private void ConfigureMovie(EntityTypeConfiguration<Movie> movie) {
            movie.Property(p => p.CreatedBy).IsRequired();
            movie.Property(p => p.CreatedOn).IsRequired();
            movie.Ignore(m => m.Actors);
            movie.Ignore(m => m.Directors);
        }  

        #endregion
    }
}