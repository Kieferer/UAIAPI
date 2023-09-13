using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIAPI.Controllers;
using UAIAPI.Models;
using UAIAPI.Services;

namespace UAIAPITest
{
    internal class ApiControllerTests
    {
        private Mock<ReleaseService> mockReleaseService;
        private ApiController apiController;

        [SetUp]
        public void Setup()
        {
            mockReleaseService = new Mock<ReleaseService>();
            apiController = new ApiController(mockReleaseService.Object);
        }
    }
}