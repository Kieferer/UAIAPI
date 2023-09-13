using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UAIAPITest
{
    internal class ApiControllerTests
    {
        private Mock<ReleaseService> mockReleaseService;
        private ApiController apiController;

        readonly string appName = "testAppName";
        readonly string version = "testVersion";
        readonly string notes = "testNotes";

        Dictionary<string, PlatformData> appReleaseData;

        [SetUp]
        public void Setup()
        {
            mockReleaseService = new Mock<ReleaseService>();
            apiController = new ApiController(mockReleaseService.Object);
            appReleaseData = new Dictionary<string, PlatformData>();
        }

        [Test]
        public void SetUpdateDataTest()
        {
            var releaseDataDAO = new ReleaseDataDAO(appName, version, notes, appReleaseData);

            var result = apiController.SetUpdateData(releaseDataDAO);

            Assert.IsInstanceOf<ContentResult>(result);
            mockReleaseService.Verify(service => service.SetOrUpdateRelease(It.IsAny<string>(), It.IsAny<ReleaseData>()), Times.Once);
        }

        [Test]
        public void GetUpdateDataTest()
        {
            mockReleaseService.Setup(service => service.GetReleaseData(appName)).Returns(new ReleaseData(version, notes, appReleaseData));

            var result = apiController.GetUpdateData(appName);

            Assert.IsInstanceOf<ContentResult>(result);
            mockReleaseService.Verify(service => service.GetReleaseData(appName), Times.Once);
        }
    }
}