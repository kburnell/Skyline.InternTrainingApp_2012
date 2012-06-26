using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.InternTrainingApp.Common.Interfaces.ExternalServices;
using Skyline.InternTrainingApp.ExternalServices.RottenTomatoes;

namespace ITA.ExternalServices.Tests.Integration.RottenTomatoes {

    [TestClass]
    public class RottenTomatoesServiceTest {

        #region << Private Fields >>

        private static IRottenTomatoesService _service;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _service = new RottenTomatoesService();
        }

        [TestCleanup]
        public void TestCleanup() {
            _service = null;
        }

        #endregion

        [TestMethod]
        public void GetByTitle_ShouldDoSomething() {
            //Arrange
            string title = "Reservoir Dogs";
            //Act
            _service.GetByTitle(title);
            //Assert
            }

    }
}