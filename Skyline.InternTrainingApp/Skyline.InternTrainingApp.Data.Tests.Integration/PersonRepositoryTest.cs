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
    public class PersonRepositoryTest {

        private IPersonRepository _repository;
        private UnitOfWork _unitOfWork;

        [ClassInitialize]
        public static void ClassInitializer(TestContext context) {
            Database.SetInitializer(new ITADataContextIntegrationTestInitializer());
        }


        [TestInitialize]
        public void TestInitialize() {
            ObjectFactory.Initialize(x => { x.For<ITADataContextBase>().Use<ITADataContext>(); });
            _unitOfWork = new UnitOfWork();
            _repository = new PersonRepository();
            _repository.SetUnitOfWork(_unitOfWork);
        }

        [TestCleanup]
        public void TestCleanup() {
            _repository = null;
        }

        [TestMethod]
        public void GetByPersonType_ShouldReturn_ListOf_Person() {
            //Arrange
            PersonType personType = PersonType.Actor;
            //Act
            var result = _repository.GetByPersonType(personType);
            //Assert
            result.ShouldBeType<List<Person>>();
        }

        [TestMethod]
        public void GetByPerson_Should_ListOf_Person_OfType_Actor_When_PersonType_IsActor() {
            //Arrange
            PersonType personType = PersonType.Actor;
            //Act
            IList<Person> result = _repository.GetByPersonType(personType);
            //Assert
            result.Count(x => x.PersonType == PersonType.Director).ShouldEqual(0);
        }

        [TestMethod]
        public void GetByPerson_Should_ListOf_Person_WithCountOf_4_OfType_Actor_When_PersonType_IsActor() {
            //Arrange
            PersonType personType = PersonType.Actor;
            //Act
            IList<Person> result = _repository.GetByPersonType(personType);
            //Assert
            result.Count(x => x.PersonType == PersonType.Actor).ShouldEqual(4);
        }

        

    }
}