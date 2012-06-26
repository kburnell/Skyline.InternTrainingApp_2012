using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ITA.Common.Enumerations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.InternTrainingApp.Common.DataContext;
using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.Interfaces.Data;
using Should;
using Skyline.InternTrainingApp.Common.UnitOfWork;
using Skyline.InternTrainingApp.Data.Tests.Integration.TestDataContext;
using StructureMap;

namespace Skyline.InternTrainingApp.Data.Tests.Integration {

    [TestClass]
    public class MovieRepositoryTest {

        private IMovieRepository _repository;
        private UnitOfWork _unitOfWork;

        [ClassInitialize]
        public static void ClassInitializer(TestContext context) {
            Database.SetInitializer(new ITADataContextIntegrationTestInitializer());
        }


        [TestInitialize]
        public void TestInitialize() {
            ObjectFactory.Initialize(x => { x.For<ITADataContextBase>().Use<ITADataContext>(); });
            _unitOfWork = new UnitOfWork();
            _repository = new MovieRepository();
            _repository.SetUnitOfWork(_unitOfWork);
        }

        [TestCleanup]
        public void TestCleanup() {
            _repository = null;
        }

        [TestMethod]
        public void All_ShouldReturn_ListOf_Movie() {
            //Act
            var result = _repository.All();
            //Assert
            result.ShouldBeType<List<Movie>>();
        }

        [TestMethod]
        public void All_ShouldReturn_All_Movies_FromThe_MovieTable() {
            //Act
            IList<Movie> movies = _repository.All();
            //Assert
            movies.Count.ShouldEqual(_unitOfWork.Context.Movies.Count());
        }

        [TestMethod]
        public void All_ShouldReturn_ListOfMovies_Including_Genres() {
            //Act
            IList<Movie> movies = _repository.All();
            //Assert
            movies[0].Genres.ShouldNotBeNull();
        }

        [TestMethod]
        public void All_ShouldReturn_ListOfMovies_Including_2Genres_ForMovie_With_IdOf1() {
            //Act
            IList<Movie> movies = _repository.All();
            //Assert
            movies[0].Genres.Count.ShouldEqual(2);
        }

    }
}