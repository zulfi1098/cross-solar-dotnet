using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Domain;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CrossSolar.Tests.Controller
{
   public class AnalyticsControllerTests
    {
        private AnalyticsController _analyticsController;

        private Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();
        private Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        public AnalyticsControllerTests()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
        }

        [Fact]
        public async Task Get_ShouldExistsAnalytics()
        {

            // Arrange

            // Act
            var result =  await _analyticsController.Get("AAAA1111BBBB2222");

            // Assert
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public async Task DayResults_ShouldExists()
        {

            // Arrange
            string pandelId = "AAAA1111BBBB2222";
            // Act
            var result = await _analyticsController.DayResults(pandelId);

            // Assert
            var contentResult = result as OkObjectResult;
            Assert.NotNull(contentResult);
            Assert.Equal(200, contentResult.StatusCode);
        }

        [Fact]
        public async Task Post_ShouldInsertPanelAnalytics()
        {


            // Arrange
            string pandelId = "AAAA1111BBBB2222";
            var panelAnalytics = new OneHourElectricityModel
            {
                KiloWatt = 1,
                DateTime = System.DateTime.Now
            };
            // Act
            var result = await _analyticsController.Post(pandelId,panelAnalytics);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

    }

}
