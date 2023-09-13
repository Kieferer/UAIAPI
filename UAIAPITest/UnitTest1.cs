using UAIAPI.Builders;
using UAIAPI.Models;

namespace UAIAPITest
{
    public class Tests
    {
        readonly string version = "testVersion";
        readonly string notes = "testNotes";
        readonly string signature = "testSig";
        readonly string url = "testURL";
        readonly string platform = "testPlatform";

        Dictionary<string, PlatformData> appReleaseData;

        PlatformData platformData;
        PlatformData platformDataFromBuilder;
        ReleaseData releaseData;
        ReleaseData releaseDataFromBuilder;

        [SetUp]
        public void Setup()
        {
            appReleaseData = new Dictionary<string, PlatformData>();

            platformData = new PlatformData(signature, url);
            releaseData = new ReleaseData(version, notes, appReleaseData);

            platformDataFromBuilder = new PlatformDataBuilder()
                .SetSignature(signature)
                .SetUrl(url)
                .Build();

            releaseDataFromBuilder = new ReleaseDataBuilder()
                .SetVersion(version)
                .SetNotes(notes)
                .SetPlatform(appReleaseData)
                .AddPlatform(platform, platformData)
                .Build();
        }

        [Test]
        public void platformDataTest()
        {
            Assert.That(platformData.Signature, Is.EqualTo(signature));
            Assert.AreEqual(url, platformData.Url);
        }
        [Test]
        public void releaseDataTest()
        {
            Assert.AreEqual(version, releaseData.Version);
            Assert.AreEqual(notes, releaseData.Notes);
            Assert.AreEqual(appReleaseData, releaseData.Platforms);
        }

        [Test]
        public void platformDataFromBuilderTest()
        {
            Assert.AreEqual(signature, platformDataFromBuilder.Signature);
            Assert.AreEqual(url, platformDataFromBuilder.Url);
        }
        [Test]
        public void releaseDataFromBuilderTest()
        {
            Assert.AreEqual(version, releaseDataFromBuilder.Version);
            Assert.AreEqual(notes, releaseDataFromBuilder.Notes);
            Assert.AreEqual(appReleaseData, releaseDataFromBuilder.Platforms);
        }
    }
}