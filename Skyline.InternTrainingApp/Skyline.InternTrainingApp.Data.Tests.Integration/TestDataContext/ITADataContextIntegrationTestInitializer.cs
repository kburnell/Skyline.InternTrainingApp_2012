using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.DataContext;
using Skyline.InternTrainingApp.Common.Domain;

namespace Skyline.InternTrainingApp.Data.Tests.Integration.TestDataContext {

    /// <summary>
    /// Data Context Initializer for running Integration Tests
    /// </summary>
    public class ITADataContextIntegrationTestInitializer : DropCreateDatabaseAlways<ITADataContext> {

        #region << Private Fields >>

        private const string CreatedBy = "Test - SeededData";
        private readonly DateTime _createdOn = DateTime.Now;
        private Person _actor1;
        private Person _actor2;
        private Person _actor3;
        private Person _actor4;
        private Person _director1;
        private Person _director2;
        private Genre _genre1;
        private Genre _genre2;
        private Genre _genre3;
        private Genre _genre4;

        #endregion

        #region << Public/Protected Methods >>

        protected override void Seed(ITADataContext context) {
            SeedPerson(context);
            SeedGenre(context);
            SeedMovie(context);
            base.Seed(context);
            try {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                //Entity validation exception, so something didn't validate
                //Do Microsoft's job and make clear what actually happened so we can fix it!
                StringBuilder errMsg = new StringBuilder();
                foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors) {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors) {
                        errMsg.AppendLine(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw new InvalidOperationException(errMsg.ToString(), dbEx.InnerException);
            }
        }

        #endregion

        private void SeedPerson(ITADataContext context) {
            _actor1 = new Person {FullName = "Steve Buscemi", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Actor, IsActive = true};
            _actor2 = new Person { FullName = "George Clooney", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Actor, IsActive = true };
            _actor3 = new Person { FullName = "Matt Damon", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Actor, IsActive = true };
            _actor4 = new Person { FullName = "Julia Roberts", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Actor, IsActive = true };
            _director1 = new Person { FullName = "Steven Spielberg", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Director, IsActive = true };
            _director2 = new Person { FullName = "Michael Bay", CreatedBy = CreatedBy, CreatedOn = _createdOn, PersonType = PersonType.Director, IsActive = true };
            new List<Person> {_actor1, _actor2, _actor3, _actor4, _director1, _director2}.ForEach(p => context.People.Add(p));
        }

        private void SeedGenre(ITADataContext context) {
            _genre1 = new Genre { Title = "Comedy", CreatedBy = CreatedBy, CreatedOn = _createdOn, IsActive = true };
            _genre2 = new Genre { Title = "Action", CreatedBy = CreatedBy, CreatedOn = _createdOn, IsActive = true };
            _genre3 = new Genre { Title = "Horror", CreatedBy = CreatedBy, CreatedOn = _createdOn, IsActive = true };
            _genre4 = new Genre { Title = "Drama", CreatedBy = CreatedBy, CreatedOn = _createdOn, IsActive = true };
            new List<Genre> {_genre1, _genre2, _genre3, _genre4}.ForEach(g => context.Genres.Add(g));
        }

        private void SeedMovie(ITADataContext context) {
            Movie movie1 = new Movie  {
                Title = "Oceans Eleven", 
                MpaaRating = "PG-13", 
                ReleaseDate = new DateTime(2003, 1, 1), 
                AudienceRating = 88, 
                Synopsis = "They steal stuff", 
                People = new List<Person> {_actor2, _actor3, _actor4, _director1}, 
                Genres = new List<Genre> {_genre1, _genre2}, 
                CreatedBy = CreatedBy, 
                CreatedOn = _createdOn,
                IsActive = true
            };
            Movie movie2 = new Movie {
                Title = "Oceans Thirteen",
                MpaaRating = "PG-13",
                ReleaseDate = new DateTime(2008, 1, 1),
                AudienceRating = 75,
                Synopsis = "They steal more stuff",
                People = new List<Person> { _actor1, _actor3, _actor4, _director2},
                Genres = new List<Genre> { _genre3, _genre4 },
                CreatedBy = CreatedBy,
                CreatedOn = _createdOn,
                IsActive = true
            };
            new List<Movie> {movie1, movie2}.ForEach(m => context.Movies.Add(m));
        }

    }
}