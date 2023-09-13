using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIAPI.Models;
using UAIAPI.Services;

namespace UAIAPITest
{
    internal class ReleaseServiceTests
    {
        private ReleaseService releaseService;

        readonly string appName = "testAppName";
        readonly string version = "testVersion";
        readonly string notes = "testNotes";

        Dictionary<string, PlatformData> appReleaseData;

        [SetUp]
        public void Setup()
        {
            releaseService = new ReleaseService();
            appReleaseData = new Dictionary<string, PlatformData>();
        }

        [Test]
        public void setOrUpdateReleaseTest()
        {
            var release = new ReleaseData(version, notes, appReleaseData);

            releaseService.SetOrUpdateRelease(appName, release);

            Assert.AreEqual(release, releaseService.GetReleaseData(appName));
        }
    }
}