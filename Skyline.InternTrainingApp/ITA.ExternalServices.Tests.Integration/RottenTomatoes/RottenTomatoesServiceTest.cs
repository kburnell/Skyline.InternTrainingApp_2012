using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.Interfaces.ExternalServices;
using Skyline.InternTrainingApp.Common.RequestResponse;
using Skyline.InternTrainingApp.ExternalServices.RottenTomatoes;
using Should;

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
        public void GetByTitle_ShouldReturn_BusinessServiceItemResponse_of_Movie() {
            //Arrange
            string title = "Reservoir Dogs";
            //Act
            var result = _service.GetByTitle(title);
            //Assert
            result.ShouldBeType<BusinessServiceItemResponse<Movie>>();
        }

        [TestMethod]
        public void GetByTitle_ShouldReturn_BusinessServiceItemResponse_With_ApplicationErrors_Containing_1Item_WhenNo_Movie_WithTitleExists() {
            //Arrange
            string title = "XxYyZz123";
            //Act
            BusinessServiceItemResponse<Movie> result = _service.GetByTitle(title);
            //Assert
            result.ApplicationErrors.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturn_BusinessServiceItemResponse_With_ApplicationErrors_Containing_1Item_WhenMoreThan1_Movie_WithTitleExists() {
            //Arrange
            string title = "Batman";
            //Act
            BusinessServiceItemResponse<Movie> result = _service.GetByTitle(title);
            //Assert
            result.ApplicationErrors.Count.ShouldEqual(1);
        }

    }
}